using UnityEngine;

public class MarsFloorGenerator : MonoBehaviour
{
    #region Prefab References and Game Settings

    [Header("Mars Floor Generation Settings")]
    [Tooltip("The ground prefab for the Mars floor.")]
    public GameObject groundPrefab;  // Flat ground for the base layer.

    [Header("Layer 1 - Rocks, Stones, and Minerals")]
    [Tooltip("Prefabs for small rocks, stones, and minerals.")]
    public GameObject[] smallRocksPrefabs;  // Array of small rocks and minerals.

    [Header("Layer 2 - Large Rocks and Meteorites")]
    [Tooltip("Prefabs for large rocks, meteorites, and big space junk.")]
    public GameObject[] largeRocksPrefabs;  // Array of large rocks and meteorites.

    [Header("Misc Settings")]
    [Tooltip("The number of rocks to generate in each layer.")]
    public int smallRocksCount = 200;  // Number of small rocks to place on the ground.
    public int largeRocksCount = 30;   // Number of large rocks/meteorites to place on the ground.

    [Tooltip("Size multiplier for randomizing the spread of rocks.")]
    public float spreadSize = 50f;  // Spread the rocks across a larger area.

    [Tooltip("Height of the floor (how high the rocks are positioned above the ground).")]
    public float rockHeight = 0f;  // Default rock height (y-position).

    [Tooltip("Y-axis rotation for adjusting the floor's angle.")]
    public float floorRotation = 0f;  // Rotation for the floor.

    #endregion

    void Start()
    {
        GenerateMarsFloor();
    }

    #region Mars Floor Generation Logic

    /// <summary>
    /// Generates a Mars-like surface with different layers of rocks, stones, and meteorites.
    /// </summary>
    void GenerateMarsFloor()
    {
        // Ensure all required prefabs are assigned.
        if (groundPrefab == null || smallRocksPrefabs.Length == 0 || largeRocksPrefabs.Length == 0)
        {
            Debug.LogError("Missing prefabs! Make sure all prefab arrays are assigned.");
            return;
        }

        // Generate the base ground layer (flat ground).
        GenerateGroundLayer();

        // Generate small rocks, stones, and minerals (Layer 1).
        GenerateSmallRocks();

        // Generate large rocks and meteorites (Layer 2).
        GenerateLargeRocks();

        Debug.Log("Mars floor generated with various rocks, stones, and meteorites.");
    }

    /// <summary>
    /// Generates the flat ground layer using the ground prefab.
    /// </summary>
    void GenerateGroundLayer()
    {
        // Instantiate the ground prefab at the origin with the specified rotation.
        GameObject ground = Instantiate(groundPrefab, Vector3.zero, Quaternion.Euler(0, floorRotation, 0));
        ground.transform.localScale = new Vector3(100, 1, 100);  // Scale the ground to cover a large area.
    }

    /// <summary>
    /// Generates small rocks and minerals scattered across the surface.
    /// </summary>
    void GenerateSmallRocks()
    {
        for (int i = 0; i < smallRocksCount; i++)
        {
            // Randomize position for each rock in the spread area.
            Vector3 randomPosition = new Vector3(
                Random.Range(-spreadSize, spreadSize), 
                rockHeight, 
                Random.Range(-spreadSize, spreadSize)
            );

            // Randomly pick a small rock prefab.
            GameObject randomRock = smallRocksPrefabs[Random.Range(0, smallRocksPrefabs.Length)];

            // Instantiate the selected small rock at the random position.
            Instantiate(randomRock, randomPosition, Quaternion.identity);
        }
    }

    /// <summary>
    /// Generates large rocks and meteorites scattered across the surface.
    /// </summary>
    void GenerateLargeRocks()
    {
        for (int i = 0; i < largeRocksCount; i++)
        {
            // Randomize position for each large rock in the spread area.
            Vector3 randomPosition = new Vector3(
                Random.Range(-spreadSize, spreadSize), 
                rockHeight, 
                Random.Range(-spreadSize, spreadSize)
            );

            // Randomly pick a large rock or meteorite prefab.
            GameObject randomLargeRock = largeRocksPrefabs[Random.Range(0, largeRocksPrefabs.Length)];

            // Instantiate the selected large rock at the random position.
            Instantiate(randomLargeRock, randomPosition, Quaternion.identity);
        }
    }

    #endregion
}
