using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string jumpSound;

    public Playermovement pmov;
    public GroundCheck groundCheck;
    public PoleClimbController poleClimb;
    public LedgeClimb ledgeClimb;

    private void Update()
    {
        if ((poleClimb.onPole || groundCheck.grounded) && !(ledgeClimb.ledgeHang || ledgeClimb.ledgeClimb) && Input.GetButtonDown("Jump"))
            FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
    }
}
