using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    public PlayerController PlayerControllerScript;
    public int level;

    public GameObject[] tvObstaclePrefabs;

    

    // Start is called before the first frame update
    void Start()
    {
        if (level == 1)
        {
            InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        }
        if(level == 2)
        {
            InvokeRepeating("SpawnLevel2Obstacle", startDelay, repeatRate);
        }

    }

    // Update is called once per frame
    void SpawnObstacle ()
    {
        if(PlayerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
    void SpawnLevel2Obstacle()
    {
        if(PlayerControllerScript.gameOver == false && level ==2)
        {
            int obstacleIndex = Random.Range(0, tvObstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            Vector3 rotation = new Vector3(0, 180, 0);
            Instantiate(tvObstaclePrefabs[obstacleIndex], spawnPos, Quaternion.Euler(rotation));
        }
    }
}
