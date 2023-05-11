using UnityEngine;
using UnityEngine.UI;

public class PauseManagerScript : MonoBehaviour
{
    private bool isPaused = false;
    private bool isGameStarted = false;
    private bool isButtonPressed = false;
    private Color lastColor;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject backgroundImage;
    public Button backToMainMenuButton;
    public Button backToPauseMenuButton;
    

    void Update()
    {
        if (isGameStarted && Input.GetKeyDown(KeyCode.Escape))
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

    public void SetIsGameStarted()
    {
        isGameStarted = true;
        backToMainMenuButton.gameObject.SetActive(false);
        backToPauseMenuButton.gameObject.SetActive(true);
    }

    public void SetIsGameEnded()
    {
        isGameStarted = false;
        backToMainMenuButton.gameObject.SetActive(true);
        backToPauseMenuButton.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true); 
    }

    void ResumeGame()
    {
        if (isButtonPressed)
            MakeMenuTrapnsparent();
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void ReturnToGame()
    {
        if(isGameStarted)
        {
            ResumeGame();
        }
    }

    public void MakeMenuTrapnsparent()
    {
        if (!isButtonPressed && isGameStarted)
        {
            isButtonPressed = true;
            Color currentColor = backgroundImage.GetComponent<Image>().color;
            lastColor = currentColor;
            backgroundImage.GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
        }
        else if (isGameStarted)
        {
            backgroundImage.GetComponent<Image>().color = lastColor;
            isButtonPressed = false;
        }
    }
}