using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI powerUpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int score;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public AudioClip powerSound;
    public AudioClip coinSound;

    public bool hasPowerup;
    public bool hasRunPoweup = false;
    public GameObject powerupIndicator;
    public int powerUpDuration = 10;
    public float powerupSpeed = 14.0f;

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

    public GameObject gameOverMenu;
    public Animation anim;
    private bool froze = false;

 

    // Start is called before the first frame update
    void Start()
    {
        MoveLevel.speed = 18;
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();
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
        if (froze == false && hasRunPoweup == true)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * powerupSpeed);
        }
        else if (froze == false && hasRunPoweup == false){
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * 0);
        }

        playerOnGroundCheck();
        GameOver();
    }

    public void HighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", score);
        }
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.SetText($"HIGH SCORE: {highScore}");
    }

    public void GameOver()
    {
        if (transform.position.x < -5)
        {
            gameOverMenu.SetActive(true);
            //Destroy(gameObject);
            MoveLevel.speed = 0;
            anim["m_death_A"].wrapMode = WrapMode.ClampForever;
            anim.Play("m_death_A");
            froze = true;
            HighScore();
        }
    }

    public void isOnGround()
    {
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

    public void playerOnGroundCheck()
    {
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
            else if (Input.GetKeyDown(KeyCode.Space) && hasPowerup == false)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                // Plays Ausio clip when player jumps.
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            }
        }
        else if (isGrounded == false)
        {
            speed = 3.5f;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerUpText.gameObject.SetActive(false);
        powerupIndicator.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            playerAudio.PlayOneShot(powerSound, 1.0f);
            hasPowerup = true;
            powerupIndicator.SetActive(false);
            powerUpText.gameObject.SetActive(true);
            StartCoroutine(PowerupCooldown());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("jumpPowerup"))
        {
            playerAudio.PlayOneShot(powerSound, 1.0f);
            hasPowerup = true;
            powerupIndicator.SetActive(false);
            powerUpText.gameObject.SetActive(true);
            StartCoroutine(PowerupCooldown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("GoldCoin"))
        {
            playerAudio.PlayOneShot(coinSound, 1.0f);
            UpdateScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("BlueCoin"))
        {
            playerAudio.PlayOneShot(coinSound, 1.0f);
            UpdateScore(5);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("RedCoin"))
        {
            playerAudio.PlayOneShot(coinSound, 1.0f);
            UpdateScore(10);
            Destroy(collision.gameObject);
        }
    }

}
