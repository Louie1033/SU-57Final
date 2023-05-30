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

    
    public float minSideZ = -10;
    public float maxSideZ = -1;
    public float sideX = 28;


    

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
            
            Vector3 spawnPos = new Vector3(sideX, 0, Random.Range(minSideZ, maxSideZ));

            Vector3 rotation = new Vector3(0, 0, 0);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.Euler(rotation));
        }
    }
}
