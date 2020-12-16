using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1;
        Coin.value = 0;
        SceneManager.LoadScene("InGame");
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        Coin.value = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
