using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleDisableCollider : MonoBehaviour
{

    //////////THIS SCRIPT IS TO BE USED ON A GROUND TILE THAT HAS A POLE RUNNING THROUGH IT//////////

    //One way to implement this:
    //CREATE A PREFAB OUT OF A GROUND TILE, ATTACH THIS SCRIPT AND A PLATFORM EFFECTOR 2D, WITH ONE WAY ENABLED AND THE RELAVENT CHARACTER'S/OBJECT'S LAYER SET ON THE LAYERMASK
    //PLACE A POLE PREFAB BEHIND THE GROUND TILE, OR AN OBJECT ON THE POLE LAYER WITH A BOX COLLIDER (IN THE SHAPE OF A POLE) SET AS A TRIGGER. MAKE THIS A CHILD OF THE GROUND PREFAB
    //MAKE TWO MORE CHILD OBJECTS OF THE GROUND TILE, TITLED "MakeshiftGround" AND "MakeshiftGround2"
    //TAG THESE TWO CHILD OBJECTS AS "MakeshiftGround" AND "MakeshiftGround2", RESPECTIVELY.
    //PLACE A TRIGGER COLLIDER ON EACH OF THE MAKESHIFT GROUND OBJECTS. THESE WILL BE USED BY THE POLE CLIMB SCRIPT TO ALLOW THE CHARACTER TO WALK OFF THE POLE WHEN THEIR FEET ARE ON THE GROUND
    //ADJUST THEM IN SUCH A WAY THAT WHEN THE CHARACTER IS INSIDE BOTH OF THE MAKESHIFT GROUND TRIGGERS, THEIR FEET ARE CLOSE TO THE GROUND
    //ONE SHOULD BE LINED UP WITH (OR SLIGHTLY ABOVE) THE GROUND TILE, AND THE OTHER ABOVE THE GROUND TILE AT A DISTANCE SPECIFIC TO THE CHARACTER'S HEIGHT
     PoleClimbController poleClimb;
     Pole pole;
     GroundCheck groundCheck;
    public Collider2D onPoleDisableCollider;

    private void Start()
    {
        poleClimb = FindObjectOfType<PoleClimbController>();
        pole = FindObjectOfType<Pole>();
        groundCheck = FindObjectOfType<GroundCheck>();
    }

    void Update()
    {
        if (poleClimb.onPole)//------------------------------If the character is on a pole
        {
            if (onPoleDisableCollider != null)//--------If there is a collider selected to disable when on a pole
                onPoleDisableCollider.enabled = false;//Disable the collider, allowing the character pass through
        }
        if (!poleClimb.onPole)//------------------------If the character is not on a pole
        {
            if (groundCheck.grounded || (pole.makeshiftGrounded && pole.makeshiftGrounded2)){//if the character is grounded or the characters feet are touching the ground
            if (onPoleDisableCollider != null)//--------If there is a collider selected to disable when on a pole
                onPoleDisableCollider.enabled = true;}//-Enable the collider, allowing the character to walk across it

      
        }
    }
}
