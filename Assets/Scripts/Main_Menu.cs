using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{

    // public GameObject player;
    public void PlayGame()
    {
                Deneme.gameOver=false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
         SceneManager.LoadScene("Menu");
    }

        public void Replay()
    {
        Deneme.gameOver=false;
        Time.timeScale = 1.0f;
         SceneManager.LoadScene("Game");
    }

}
