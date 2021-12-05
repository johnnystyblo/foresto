using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinScript : MonoBehaviour
{
    private Renderer rend;
    private CircleCollider2D circle;
    public int coinValue = 1;
    AudioSource zvuk;
    // This Will Configure the  AudioSource Component; 

    void OnTriggerEnter2D(Collider2D col)  //Plays Sound Whenever collision detected
    {
        rend = GetComponent<SpriteRenderer>(); // gets sprite renderer
        circle = GetComponent<CircleCollider2D>();

        if (col.gameObject.tag.Equals("Player"))
        {
            zvuk.Play();
            rend.enabled = false; // sets to false if hit.
            circle.enabled = false;
            Invoke("Die", 0.6f);
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        zvuk = GetComponent<AudioSource>();
    }
}