using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject bg;
    private float spawnPosY = 4;
    private float spawnPosX = 265.9f;
    private float spawnPosZ = 11;
    private float spawnInterval = 12.7199f;
    private float powerupspawnInterval = 7.0f;
    private float obstacleSpawnInterval = 0.5f;
    

        // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBackground", 0);
        InvokeRepeating("SpawnObjects", 0 , obstacleSpawnInterval);
        InvokeRepeating("SpawnPowerups", 0, powerupspawnInterval);
    }

    void SpawnBackground()
    {
        
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        Instantiate(bg, spawnPos, bg.transform.rotation);
        Invoke("SpawnBackground", spawnInterval);
    }


    //spawn obstacles 
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(130,0, Random.Range(-5.8f, 4.6f));
        int index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], spawnLocation, obstaclePrefabs[index].transform.rotation);

        // If game is still active, spawn new object
        //if (playerControllerScript.gameOver == false)
       // {
           // Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        //}
    }
    void SpawnPowerups()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation1 = new Vector3(130, 0, Random.Range(-5.8f, 4.6f));
        int index = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[index], spawnLocation1, powerupPrefabs[index].transform.rotation);

        // If game is still active, spawn new object
        //if (playerControllerScript.gameOver == false)
        // {
        // Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        //}
    }
}


