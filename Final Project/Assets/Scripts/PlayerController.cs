using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public AudioClip powerSound;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 15;
     // how hard to hit enemy without powerup
    private float powerupJump = 12; 

    public float horizontalInput;
    public float speed = 7.0f;
    public float zRangeLeft = 5.8f;
    public float zRangeRight = -6.8f;

    public bool isGrounded = true;

    public LayerMask groundlayers;
    public float jumpForce = 9;
    private Rigidbody rb;
    public BoxCollider collider;

    public GameObject gameOverMenu;

 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
            Destroy(other.gameObject);
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        isOnGround();
        if (isGrounded == true)
        {
            speed = 7;
            if (Input.GetKeyDown(KeyCode.Space) && hasPowerup == true)
            {
                rb.AddForce(Vector3.up * powerupJump, ForceMode.Impulse);
                // Plays Ausio clip when player jumps.
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && hasPowerup == false){
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                // Plays Ausio clip when player jumps.
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
        else if (isGrounded == false)
        {
            speed = 3.5f;
        }

        if (transform.position.x < -7.83) {
            gameOverMenu.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void isOnGround() {
        RaycastHit hit;
        float distance = 1f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            playerAudio.PlayOneShot(powerSound, 1.0f);
        }
    }

}
