using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtonManager : MonoBehaviour
{
    public GameObject endMenu;
    public void EndGame()
    {
        Time.timeScale = 0;
        endMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Data.restart();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
