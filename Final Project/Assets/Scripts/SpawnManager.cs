using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject bg;
    private float spawnPosY = 4;
    private float spawnPosX = 265.9f;
    private float spawnPosZ = 11;
    private float spawnInterval = 12.7199f;
    private float obstacleSpawnInterval = 4.0f;
    

        // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBackground", 0);
        InvokeRepeating("SpawnObjects", 2.0f,obstacleSpawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnBackground()
    {
        
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        // instantiate ball at random spawn location
        Instantiate(bg, spawnPos, bg.transform.rotation);
        Invoke("SpawnBackground", spawnInterval);
    }


    //spawn obstacles 
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(130,0,Random.Range(-5.4f, 5.4f));
        int index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], spawnLocation, obstaclePrefabs[index].transform.rotation);
        

        // If game is still active, spawn new object
        //if (playerControllerScript.gameOver == false)
       // {
           // Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        //}
    }
}


