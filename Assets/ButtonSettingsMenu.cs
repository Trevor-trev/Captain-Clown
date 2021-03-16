using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettingsMenu : MonoBehaviour
{

    public GameObject buttonSettingsUI;
    public GameObject startMenuUI;
    public GameObject pauseMenuUI;

    public MainMenu mainMenu;
public void GoBack()
    {
       if (mainMenu.fromMainMenu)
        {
            buttonSettingsUI.SetActive(false);
            startMenuUI.SetActive(true);
        }
        else
        {
            buttonSettingsUI.SetActive(false);
            pauseMenuUI.SetActive(true);
        }

    }
}
