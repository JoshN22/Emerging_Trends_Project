using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombies : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MoveZombieDown();

    }

    public void MoveZombieDown()
    {
        if (gameObject.transform.position.x > -2)
        {
            rb.AddForce(-transform.right * 50 * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
