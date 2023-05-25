using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtonManager : MonoBehaviour
{
    public GameObject player; //mojno ubrat
    int score = 0; //mojno ubrat
    public void RestartGame()
    {
        
        Debug.Log("Restart"); //mojno ubrat
        SaveResult(); //mojno ubrat
        Time.timeScale = 1;
        //SceneManager.LoadScene("imya sceni, kotoraya doljna zapustista");

    }

    public void ToMainMenu()
    {
        Debug.Log("To Main Menu"); //mojno ubrat
        SaveResult(); //mojno ubrat
        Time.timeScale = 1;
        //SceneManager.LoadScene("scena menu");
    }

    private void SaveResult()
    {
        //score = player.GetComponent<GameManager>().score; //mojno ubrat
        PlayerPrefs.SetInt("score", score); //mojno ubrat
    }
}
