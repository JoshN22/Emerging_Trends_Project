using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed = 18;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

    }
}
