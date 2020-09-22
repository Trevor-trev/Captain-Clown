using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string pogoSound;
    public bool playingSound;

    public Playermovement pmov;
    public GroundCheck groundCheck;

    IEnumerator PlaySound()
    {
        playingSound = true;
        yield return new WaitForFixedUpdate();
        playingSound = false;
    }
    private void FixedUpdate()
    {        
        if (pmov.pogo && groundCheck.grounded)
        {
            StartCoroutine("PlaySound");
            PlaySound();
        }
            

        if (playingSound)
            FMODUnity.RuntimeManager.PlayOneShot(pogoSound);            
    }
}
