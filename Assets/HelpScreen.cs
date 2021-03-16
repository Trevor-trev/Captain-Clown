using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour
{
    public GameObject helpScreen;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;

    public MainMenu mainMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu.fromMainMenu)
            {
                helpScreen.SetActive(false);
                mainMenuUI.SetActive(true);
            }
            else
            {
                helpScreen.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
        }
    }
}
