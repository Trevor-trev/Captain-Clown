using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class JumpSound : MonoBehaviour
{
    public string jumpSound;

    public Playermovement pmov;
    public GroundCheck groundCheck;
    public PoleClimbController poleClimb;
    public LedgeClimb ledgeClimb;
    public DoorwayCheck doorwayCheck;
    public KeyBindScript keybinds;
    public ThumbsUpLoadingScreen loadingScreen;

    private void Update()
    {
        if (Time.timeScale != 0 && loadingScreen.gameHasStarted)
        {
            if ((poleClimb.onPole || groundCheck.grounded) && !(ledgeClimb.ledgeHang || ledgeClimb.ledgeClimb || doorwayCheck.walkingThroughDoor || pmov.lookup) && (Input.GetKeyDown(keybinds.keys["Jump Button"])))               
                RuntimeManager.PlayOneShot(jumpSound);
        }
    }
    
}
