using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Playermovement pmov;
    public static bool isPaused;

    public GameObject pauseMenuUI;
    public GameObject buttonSettingsUI;
    public GameObject targetCounter;
    public GameObject helpScreen;

    private void Start()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        targetCounter.SetActive(true);
        isPaused = false;
        pmov.isPaused = false;
        Time.timeScale = 1f;
    }

    public void OpenButtonSettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        buttonSettingsUI.SetActive(true);
    }

    public void OpenHelpScreen()
    {
        pauseMenuUI.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
