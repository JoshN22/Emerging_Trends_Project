using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bg;
    private float spawnPosY = 30;
    private float spawnPosX = 30;
    private float spawnInterval = 4.0f;
    private float startDelay = 4.0f;

        // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnBackground", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnBackground()
    {
        
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        // instantiate ball at random spawn location
        Instantiate(bg, spawnPos, bg.transform.rotation);
        Invoke("SpawnBackground", spawnInterval);
    }

}


