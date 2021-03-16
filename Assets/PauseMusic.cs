using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PauseMusic : MonoBehaviour
{
    public StudioEventEmitter musicToPause;
    public ThumbsUpLoadingScreen loadingScreen;
    private void Awake()
    {
        musicToPause = gameObject.GetComponent<StudioEventEmitter>();       
    }
    private void Update()
    {
        if ( Time.timeScale == 0 || !loadingScreen.gameHasStarted)
            musicToPause.EventInstance.setPaused(true);

        if (Time.timeScale != 0 && loadingScreen.gameHasStarted)
            musicToPause.EventInstance.setPaused(false);
    }
}
