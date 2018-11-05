using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField]
    float spawnRate = 1f;

    /// <summary>
    /// A list of GameObject preafbs, assigned in the inspector that we randomly pick from to spawn in
    /// </summary>
    [SerializeField]
    List<GameObject> objectsToSpawnFrom;

    LineRenderer lastSpawnedPrefab;
    [SerializeField]
    Color[] allColours;
    int colourIndex;

    float nextTimeToSpawn = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (GameManager.IsGameInProgress && Time.time >= nextTimeToSpawn)
        {
            CreateColliderObject();
        }
    }

    /// <summary>
    /// Randomly set a spawn rate between 0.5f and 1.2f
    /// </summary>
    public void SetNewRandomSpawnRate()
    {
        spawnRate = Random.Range(0.5f, 1.2f);
    }

    /// <summary>
    /// Creates a hexagonPrefab, sets it's colour and updates the nextTimeToSpawn
    /// </summary>
    void CreateColliderObject()
    {
        lastSpawnedPrefab = Instantiate(objectsToSpawnFrom[GetRandomIndexFromAllObjectsToSpawnFrom()], Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
        lastSpawnedPrefab.material.color = ReturnNextColourFromIndex();
        nextTimeToSpawn = Time.time + (1f / spawnRate);

    }

    /// <summary>
    /// Returns a random int between 0 and the number of items available to spawn
    /// </summary>
    /// <returns></returns>
    int GetRandomIndexFromAllObjectsToSpawnFrom()
    {
        //Don't minus one off here as Random.Range(int,int) is exclusive of the second parameter.
        int total = objectsToSpawnFrom.Count;
        return Random.Range(0, total);
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
