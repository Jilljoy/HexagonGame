using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float spawnRate = 1f;

    [SerializeField]
    GameObject hexagonPrefab;

    LineRenderer lastSpawnedPrefab;
    [SerializeField]
    Color[] allColours;
    int colourIndex;

    float nextTimeToSpawn = 0f;

    void Update()
    {
        if (GameManager.IsGameInProgress && Time.time >= nextTimeToSpawn)
        {
            CreateColliderObject();
        }
    }

    /// <summary>
    /// Creates a hexagonPrefab, sets it's colour and updates the nextTimeToSpawn
    /// </summary>
    void CreateColliderObject()
    {
        lastSpawnedPrefab = Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
        lastSpawnedPrefab.material.color = ReturnNextColourFromIndex();
        nextTimeToSpawn = Time.time + (1f / spawnRate);

    }

    /// <summary>
    /// Adds 1 to the colourIndex and returns the next colour in the array allColours.
    /// If the colourIndex goes greater than the length of the allColours array then colourIndex becomes 0.
    /// </summary>
    /// <returns></returns>
    Color ReturnNextColourFromIndex()
    {
        colourIndex++;

        if (colourIndex > allColours.Length - 1) colourIndex = 0;

        return allColours[colourIndex];
    }
}
