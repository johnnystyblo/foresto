using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject bulletPrefab;
    private string BULLET_TAG = "Bullet";
    private string BULLET_FRIENDLY = "Friendly";
    private string BLOB_TAG = "Blob";
    private string RED_TAG = "Red";
    private string PLAYER_TAG = "Player";
    private string WALL_TAG = "Wall";
    private string PLATFORM_TAG = "Platform";
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("Die", 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        if (collision.gameObject.tag == PLAYER_TAG && bulletPrefab.tag == BULLET_TAG || collision.gameObject.tag == WALL_TAG || collision.gameObject.tag == PLATFORM_TAG)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == BLOB_TAG && bulletPrefab.tag == BULLET_FRIENDLY || collision.gameObject.tag == RED_TAG && bulletPrefab.tag == BULLET_FRIENDLY)
        {
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
