using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript; // Reference to the PlayerController script
    public GameObject obstaclePrefab; // Prefab of the obstacle to spawn
    private float repeatRate = 2f; // Time interval between spawns
    private float startDelay = 2f; // Delay before the first spawn
    private Vector3 spawnPosition = new Vector3(25, 0, 0); // Position where the obstacle will spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // Call SpawnObstacle method every repeatRate seconds after an initial delay of startDelay seconds
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation); // Spawn an obstacle at the specified position
        }
    }
}
