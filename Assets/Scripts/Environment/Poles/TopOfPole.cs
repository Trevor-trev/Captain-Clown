using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopOfPole : MonoBehaviour
{
    //THIS SCRIPT PREVENTS THE CHARACTER FROM BEING ABLE TO CONTINTUE CLIMBING UP PAST THE TOP OF THE POLE.
    //ONE WAY TO INPLEMENT THIS:
    //ATTACH THIS SCRIPT TO A SEPARATE GAME OBJECT, POSSIBLY TITLED "MOVEMENT STOPPER"
    //ALSO ATTACH A TRIGGER COLLIDER TO THAT GAME OBJECT
    //SET THAT GAME OBJECT AS A CHILD OF THE "TOP OF THE POLE" SPRITE
    //FOR CONVENIENCE, MAKE THE PARENT OBJECT WITH IT'S CHILD A PREFAB
    PoleClimbController poleClimb;

    void Start()
    {
        poleClimb = FindObjectOfType<PoleClimbController>();
    }

    private void OnTriggerEnter2D(Collider2D other)//-Execute this code when the specified object enters a trigger placed at the top of the pole
    {
        if (other.CompareTag("Player"))//------------When the character reaches the trigger
        {
            if (Input.GetAxis("Vertical") > 0)//-----If the player presses the up button
                poleClimb.climbingTopSpeed = 0;//----Prevent upward movement
            else if (Input.GetAxis("Vertical") < 0)//If the player presses the down button
                poleClimb.climbingTopSpeed = 3;//----Allow downward movement
        }
    }


    private void OnTriggerStay2D(Collider2D other)//-Execute this code when the specified object enters a trigger placed at the top of the pole
    {
        if (other.CompareTag("Player"))//------------When the character reaches the trigger
        {
            if (Input.GetAxis("Vertical") > 0)//-----If the player presses the up button
                poleClimb.climbingTopSpeed = 0;//----Prevent upward movement
            else if (Input.GetAxis("Vertical") < 0)//If the player presses the down button
                poleClimb.climbingTopSpeed = 3;//----Allow downward movement
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){//-----------When the player is no longer at the top of the pole
            poleClimb.climbingTopSpeed = 1.75f;}//---Allow upward movement
    }
}
