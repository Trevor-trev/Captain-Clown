using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeCheck : MonoBehaviour
    /*This script checks if the object it's placed on is on sloping ground, in which case it can execute code to make sure the object 
      doesn't slide down when not in motion. It is intended to be placed on a game object titled "Slope Check" which has a box collider set as a trigger. 
      The Slope Check object should be set as a child of the player character*/
{
    public Playermovement pmov;

    public bool onSlope = false;//--------------------Whether or not the character is on a slope

    public Rigidbody2D rb;
    BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();//Set the boxcollider reference to the Box Collider 2D attached to the same object that this script is attached to
    }

    private void Update()
    {
        //if (pmov.pogo)
            //onSlope = false;

        if (pmov.isJumping){//----------------------------If the character is jumping        
            boxCollider.enabled = false;//----------------Diable the box collider
            rb.drag = .25f;}//----------------------------Reset the rigidbody's drag to the default value
        
        if (!pmov.isJumping)//----------------------------If the character is not jumping
            boxCollider.enabled = true;//-----------------Enable the box collider

        if (onSlope){//-----------------------------------If the character is on a slope        
            
            rb.gravityScale = 9f;//-----------------------Set the rigidbody's gravity scale to 9 to make sure the character sticks to the ground when running down the slope

            if (pmov.xdirection != 0 || pmov.pogo)//-------------------If the player is inputting horizontal movement
                rb.drag = .25f;//-------------------------Reset the rigidbody's drag to the default value

            if (pmov.xdirection == 0 && !pmov.isJumping && !pmov.pogo)//If the palyer is not inputting horizontal movement
                rb.drag = 1000000f;}//--------------------Increase the rigidbody's drag to 1,000,000 to make sure the character doesn't slide down the slope
        
    }
    private void OnTriggerEnter2D(Collider2D collider)//--Execute this code when the specified object's collider enters the collider attached to the same object as this script
    {
        if (collider.CompareTag("Slope"))//---------------If the object that entered the trigger collider is tagged "Slope"
            onSlope = true;//-----------------------------The character is on a slope
    }

    private void OnTriggerExit2D(Collider2D other) //-----Execute this code when the specified object's collider exits the collider attached to the same object as this script
    {
        if (other.CompareTag("Slope"))//------------------If the object that exited the trigger collider is tagged "Slope"
            onSlope = false;//----------------------------The character is no longer on a slope
    }
}
