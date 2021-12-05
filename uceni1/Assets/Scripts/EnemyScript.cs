using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator animator;
    private BoxCollider2D collider2d;
    private SpriteRenderer sr;
    public int health = 100;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float canShoot = 0f;
    AudioSource zvuk;
    private string PLATFORM_TAG = "Platform";
    private string GROUND_TAG = "Ground";
    private float dirX;
    [HideInInspector]
    public float speed;

    void Awake()
    {
        speed = 5f;
        dirX = 1f;
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        zvuk = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(dirX * -speed, myBody.velocity.y);
    }
    private void Update()
    {
        StopMovement();
        if (Time.time > canShoot)
        {
            Shoot();
            canShoot = Time.time + Random.Range(2f, 7f);
        }
    }
    public void StopMovement()
    {
        //animator.enabled = true;
        if (myBody.velocity.x < 1 && myBody.velocity.x > -1)
        {
            animator.enabled = false;
        }
        else if (myBody.velocity.x > 1 || myBody.velocity.x < -1)
        {
            animator.enabled = true;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        zvuk.Play();
        if (health <= 0)
        {
            sr.enabled = false;
            collider2d.enabled = false;
            Invoke("Die", 0.6f);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Invis")
        {
            dirX *= -1f;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLATFORM_TAG))
        {
            speed = 2.5f;
        }
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            speed = 5f;
        }
    }
    
}
