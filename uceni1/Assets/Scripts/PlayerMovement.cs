using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private float canJump = 0f;
    public int damage = 50;
    public Animator animator;
    private string WALK_ANIMATION = "Walk";
    private string BULLET_TAG = "Bullet";
    private string BLOB_TAG = "Blob";
    private string RED_TAG = "Red";
    private string WALL_TAG = "Wall";
    private string PLATFORM_TAG = "Platform";
    private Rigidbody2D myBody;
    private bool isFacingRight = true;
    public int health = 100;
    public int livesValue = 1;
    AudioSource zvuk;
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    public float speed = 5f;
    public int playerLives;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        zvuk = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerLives = PlayerPrefs.GetInt("PlayerLives");
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMoveKeyboard();
        PlayerJump();
        PlayerAnimation();


    }
    private void FixedUpdate()
    {
        
    }
    void PlayerMoveKeyboard()
    {
        //Pohyb
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    }
    void PlayerJump()
    //Skakani
    {
        if (Input.GetButtonDown("Jump") && isGrounded && Time.time > canJump)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = Time.time + 0.5f;


        }
    }
    void PlayerAnimation()
    {
        if (movementX > 0)
        {
            animator.SetBool(WALK_ANIMATION, false);
            animator.enabled = true;
            

        }
        else if (movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION, false);
            animator.enabled = true;
            

        }
        else
        {
            animator.SetBool(WALK_ANIMATION, true);
            animator.enabled = false;
        }

        if (movementX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movementX < 0 && isFacingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);


    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        zvuk.Play();
        if (health <= 0)
        {
            zvuk.Play();
            Die();
        }
    }
    void Die()
    {
        ScoreManager.instance.ChangeLives(livesValue);
        SceneManager.LoadScene("LoseScreen");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    //Dotek se zemi
    {

        if (collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag(WALL_TAG) || collision.gameObject.CompareTag(PLATFORM_TAG))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == BLOB_TAG || collision.gameObject.tag == RED_TAG)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == BULLET_TAG)
        {
            TakeDamage(damage);
            zvuk.Play();
        }
    }
}
       