using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        Data.enemies.Clear();
        SceneManager.LoadScene("Menu");
    }
}