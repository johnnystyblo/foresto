using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlCenter : MonoBehaviour
{
    // Start is called before the first frame update

    [HideInInspector]
    public int coinAmount;
    [HideInInspector]
    public int playerLives;
    public int isBaseballSold;
    public GameObject baseballPrefab;
    public GameObject WeaponPrice;
    [HideInInspector]
    public Text coinText;
    
    

    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerLives") <= 0)
        {
            PlayerPrefs.SetInt("CoinAmount", 0);
            PlayerPrefs.SetInt("PlayerLives", 5);
        }
        coinAmount = PlayerPrefs.GetInt("CoinAmount");
        playerLives = PlayerPrefs.GetInt("PlayerLives");
        isBaseballSold = PlayerPrefs.GetInt("BaseballSold");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();
        if (isBaseballSold == 1)
        {
            WeaponPrice.SetActive(false);
        }
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
    public void WeaponStore()
    {
        if (coinAmount >= 5 && isBaseballSold == 0)
        {
            coinAmount -= 5;
            baseballPrefab.SetActive(true);
            coinText.text = PlayerPrefs.GetInt("CoinAmount").ToString();
            PlayerPrefs.SetInt("BaseballSold", 1);
            WeaponPrice.SetActive(false);
            


        }

    }
}
