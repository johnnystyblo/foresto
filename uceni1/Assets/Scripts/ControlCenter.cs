using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlCenter : MonoBehaviour
{
    // Start is called before the first frame update

    public int coinAmount;
    public int playerLives;
    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerLives") <= 0)
        {
            PlayerPrefs.SetInt("CoinAmount", 0);
            PlayerPrefs.SetInt("PlayerLives", 5);
        }
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        playerLives = PlayerPrefs.GetInt("PlayerLives");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetIngame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }
    public void PlayButton()
    {
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
       PlayerPrefs.SetInt("PlayerLives", playerLives);
        SceneManager.LoadScene("Level1");
    }
    public void StoreButton()
    {
        SceneManager.LoadScene("Store");
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
    }
    public void MainMenuButton()
    {
        PlayerPrefs.SetInt("CoinAmount", coinAmount);
        PlayerPrefs.SetInt("PlayerLives", playerLives);
        SceneManager.LoadScene("MainMenu");
    }
}
