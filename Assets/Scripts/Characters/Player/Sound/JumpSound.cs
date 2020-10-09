using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string jumpSound;

    public Playermovement pmov;
    public GroundCheck groundCheck;

    private void Update()
    {
        if ((pmov.onPole || groundCheck.grounded) && Input.GetButtonDown("Jump"))
            FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
    }
}
