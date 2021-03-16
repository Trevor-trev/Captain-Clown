using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool isPaused;
    public bool fromMainMenu;

    public GameObject startMenuUI;
    public GameObject buttonSettingsUI;
    public GameObject playGameLoadingScreen;
    public GameObject helpScreen;

    private void Start()
    {
        isPaused = true;
        Time.timeScale = 0f;
        fromMainMenu = true;
    }

    public void PlayGame()
    {
        startMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        fromMainMenu = false;
        playGameLoadingScreen.SetActive(true);
    }

    public void OpenButtonSettingsMenu()
    {
        startMenuUI.SetActive(false);
        buttonSettingsUI.SetActive(true);
        fromMainMenu = true;
    }

    public void OpenHelpScreen()
    {
        startMenuUI.SetActive(false);
        helpScreen.SetActive(true);
        fromMainMenu = true;
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
