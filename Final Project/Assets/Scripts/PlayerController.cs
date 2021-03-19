using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float zRangeLeft = 1f;
    public float zRangeRight = 1f;
    public LayerMask groundlayers;
    public float jumpForce = 7;
    private Rigidbody rb;
    public BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the player stop if it goes to far to the left
        if (transform.position.z < zRangeRight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeRight);
        }

        // Makes the player stop if it goes to far to the right
        if (transform.position.z > zRangeLeft)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeLeft);
        }

        // Allows the user to move left or right 
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < 0.66 && transform.position.y > 0.45)
        {
            speed = 10.0f;
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        else {
            speed = 4.0f;
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void isOnGround(int yPos) {
    }
}
