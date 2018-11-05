using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField]
    float spawnRate = 1f;

    /// <summary>
    /// A list of GameObject preafbs, assigned in the inspector, to randomly pick to spawn in
    /// </summary>
    [SerializeField]
    List<GameObject> collidersToSpawn;

    /// <summary>
    /// A GameObject prefab, assigned in the inspector, that is used for the player to pickup
    /// </summary>
    [SerializeField]
    GameObject pickupToSpawn;

    /// <summary>
    /// The last spawned collider
    /// </summary>
    LineRenderer lastSpawnedCollider;

    /// <summary>
    /// The last spawned pickup
    /// </summary>
    Pickup lastSpawnedPickup;

    /// <summary>
    /// A collection of all colours for the colliders to sequentially rotate through
    /// </summary>
    [SerializeField]
    Color[] collidersColours;

    /// <summary>
    /// A collection of all colours for the pickups to randomly pick from
    /// </summary>
    [SerializeField]
    List<Color> pickupsColours;

    /// <summary>
    /// The index of the current selected colour for the collider
    /// </summary>
    int currentColliderColourIndex;

    /// <summary>
    /// The time at which we next spawn a collider.
    /// </summary>
    float nextTimeToSpawnCollider = 0f;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (GameManager.IsGameInProgress && Time.time >= nextTimeToSpawnCollider)
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
    /// Adds the paramter, amount, to the spawnRate.
    /// </summary>
    /// <param name="amount"></param>
    public void IncreaseSpawnRate(float amount)
    {
        spawnRate += amount;
    }

    /// <summary>
    /// Subtracts the parameter from the spawnRate.
    /// </summary>
    /// <param name="amount"></param>
    public void DecreaseSpawnRate(float amount)
    {
        spawnRate -= amount;
    }

    /// <summary>
    /// Creates a hexagonPrefab, sets it's colour and updates the nextTimeToSpawn
    /// </summary>
    void CreateColliderObject()
    {
        lastSpawnedCollider = Instantiate(collidersToSpawn[GetRandomIndexFromAllCollidersToSpawnFrom()], Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
        lastSpawnedCollider.material.color = ReturnNextColourFromIndex();
        nextTimeToSpawnCollider = Time.time + (1f / spawnRate);
        //if (Random.Range(0f, 1f) > 0f)
        //{
        //    CreatePickupObject();
        //}
    }

    /// <summary>
    /// Creates a pickup object, sets it's type and updates the nextTimeToSpawn
    /// </summary>
    void CreatePickupObject()
    {
        PickupType pickupType = GameManager.GetRandomPickupType();
        if (pickupType == PickupType.None) return;
        lastSpawnedPickup = Instantiate(pickupToSpawn, Vector3.up, Quaternion.identity).GetComponent<Pickup>();
        lastSpawnedPickup.transform.Rotate(Vector3.forward, 90f);
        lastSpawnedPickup.Setup(pickupType);
    }

    /// <summary>
    /// Returns a random int between 0 and the number of colliders available to spawn
    /// </summary>
    /// <returns></returns>
    int GetRandomIndexFromAllCollidersToSpawnFrom()
    {
        //Don't minus one off here as Random.Range(int,int) is exclusive of the second parameter.
        int total = collidersToSpawn.Count;
        return Random.Range(0, total);
    }

    /// <summary>
    /// Adds 1 to the colourIndex and returns the next colour in the array allColours.
    /// If the colourIndex goes greater than the length of the allColours array then colourIndex becomes 0.
    /// </summary>
    /// <returns></returns>
    Color ReturnNextColourFromIndex()
    {
        currentColliderColourIndex++;

        if (currentColliderColourIndex > collidersColours.Length - 1) currentColliderColourIndex = 0;

        return collidersColours[currentColliderColourIndex];
    }
}
