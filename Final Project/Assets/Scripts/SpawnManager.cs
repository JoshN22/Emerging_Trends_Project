using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bg;
    private float spawnPosY = 4;
    private float spawnPosX = 265.9f;
    private float spawnPosZ = 11;
    private float spawnInterval = 12.7199f;
    

        // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBackground", 0);
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

}


