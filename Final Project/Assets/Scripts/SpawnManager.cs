using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] characterPrefabs;
    public GameObject[] coinPrefabs;

    public GameObject[] powerupPrefabs;
    public GameObject bg;
    private float spawnPosY = 4;
    private float spawnPosX = 265.9f;
    private float spawnPosZ = 11;
    private float spawnInterval = 10.585f;
    private float powerupspawnInterval = 7.0f;
    private float obstacleSpawnInterval = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBackground", 0);


        int index = PlayerPrefs.GetInt("CharacterSelected", 0);

        GameObject playerObject = Instantiate(characterPrefabs[index], new Vector3(characterPrefabs[index].transform.position.x, characterPrefabs[index].transform.position.y, characterPrefabs[index].transform.position.z), characterPrefabs[index].transform.rotation);
        playerObject.SetActive(true);

        InvokeRepeating("SpawnObjects", 0, obstacleSpawnInterval);
        InvokeRepeating("SpawnCoins", 0, 1.75f);
        InvokeRepeating("SpawnPowerups", 0, powerupspawnInterval);

    }

    void SpawnBackground()
    {
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        Instantiate(bg, spawnPos, bg.transform.rotation);
        Invoke("SpawnBackground", spawnInterval);
    }


    //Spawn obstacles 
    void SpawnObjects()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(130,0, Random.Range(-5.8f, 4.6f));
        int index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], spawnLocation, Quaternion.Euler(0, Random.Range(0, 360), 0) );
        //obstaclePrefabs[index].transform.rotation
    }


    void SpawnCoins()
    {
        Vector3 spawnLocation = new Vector3(130, 1, Random.Range(-5.8f, 4.6f));
        int index = Random.Range(0, coinPrefabs.Length);
        Instantiate(coinPrefabs[index], spawnLocation, coinPrefabs[index].transform.rotation);
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


