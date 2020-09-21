using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string pogoSound;

    public Playermovement pmov;
    public GroundCheck groundCheck;

    private void FixedUpdate()
    {
        if ((pmov.pogo && groundCheck.grounded))
            FMODUnity.RuntimeManager.PlayOneShot(pogoSound);
    }
}
