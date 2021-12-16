using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    GameObject[] blobs;
    GameObject[] reds;
    public Text blobCountText;
    public Text redCountText;
    public Text coinAmount;
    public Text livesAmount;
    public int score;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        score = PlayerPrefs.GetInt("CoinAmount");
        lives = PlayerPrefs.GetInt("PlayerLives");
        livesAmount.text = lives.ToString();
        coinAmount.text = score.ToString();
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        PlayerPrefs.SetInt("CoinAmount", score);
        coinAmount.text = PlayerPrefs.GetInt("CoinAmount").ToString();
    }
    public void ChangeLives(int livesValue)
    {
        lives -= livesValue;
        PlayerPrefs.SetInt("PlayerLives", lives);
    }
    // Update is called once per frame
    void Update()
    {
        EnemyCount();
    }
    void EnemyCount()
    {
        blobs = GameObject.FindGameObjectsWithTag("Blob");
        reds = GameObject.FindGameObjectsWithTag("Red");
        blobCountText.text = blobs.Length.ToString();
        redCountText.text = reds.Length.ToString();

        if (blobs.Length == 0 & reds.Length == 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
