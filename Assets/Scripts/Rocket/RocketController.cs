using UnityEngine;

public class RocketController : MonoBehaviour
{
    [Header("Rocket Settings")]
    public float thrustForce = 10f;
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
        if (Input.GetKey(KeyCode.Space) && currentFuel > 0)
        {
            rb.AddForce(Vector3.up * thrustForce, ForceMode.Force);
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Max(currentFuel, 0f);
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
    
