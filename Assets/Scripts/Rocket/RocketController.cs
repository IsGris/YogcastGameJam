using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Header("Rocket Settings")]
    public float thrustForce = 1.5f;
    public float rotateForce = 0.5f;
    public float fuelCapacity = 100f;
    public float fuelConsumptionRate = 1f;
    public float landingSpeedThreshold = 5f;

    public bool isBroken = false;

    private Rigidbody rb;
    private float currentFuel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        currentFuel = fuelCapacity;
    }

    private void Update()
    {
        if (isBroken)
        {
            return;
        }
        HandleThrust();
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.W) && currentFuel > 0)
        {
            rb.AddForce(transform.up * thrustForce, ForceMode.Force);
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Max(currentFuel, 0f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.right * (Input.GetKey(KeyCode.A) ? -1 : 1) * rotateForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken)
        {
            return;
        }
        float landingSpeed = rb.linearVelocity.magnitude;
        Debug.Log("Landing speed: " + landingSpeed);
        if (landingSpeed > landingSpeedThreshold)
        {
            BreakRocket();
        }
    }

    private void BreakRocket()
    {
        isBroken = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Debug.Log("Rocket is broken!");
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Fuel: " + currentFuel);
    }

}

