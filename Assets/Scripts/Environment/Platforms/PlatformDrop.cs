using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformDrop : MonoBehaviour
{

    //THIS SCRIPT ALLOWS THE PLAYER CHARACTER TO DROP THROUGH THE OBJECT IN WHICH IT IS ATTACHED BY PRESSING THE JUMP BUTTON WHILE ALSO PRESSING OR HOLDING THE LOOKDOWN BUTTON
    //FOR THIS TO WORK THE OBJECT NEEDS TO HAVE A PLATFORM EFFECTOR 2D. WHATEVER LAYERS YOU WANT TO BE ABLE TO DROP THROUGH NEED TO BE SELECTED IN THE COLLIDER MASK
    //ONE WAY TO IMPLEMENT THIS IS TO HAVE A SEPARATE TILEMAP WITH THE PLATFORM EFFECTOR 2D AND THIS SCRIPT ATTACHED, AND ONLY USE THAT TILEMAP FOR DROPPABLE PLATFORMS
    
    private PlatformEffector2D effector;//---------An effector component that changes the collidable surface angle of the object in which it is attached
    public Playermovement pmov;
    public GroundCheck groundCheck;
    public bool platformFlip;//--------------------Whether or not the collidable surface of the platform is flipped
    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    IEnumerator DropThrough ()
    {
        pmov.jumpForce = 0;
        gameObject.layer = 11;//----------The platform's layer is set to #11 ("droppable") which is not designated as ground, this prevents the idle animation from playing when the character is dropping through the platform
        effector.rotationalOffset = 180f;//The collidable surface of the platform is rotated 180 degrees
        platformFlip = true;//-------------The platform is now flipped
        if (this.gameObject.CompareTag("ClosestMovingPlatform"))
            yield return new WaitForSeconds(1f);
        else
            yield return new WaitForSeconds(.3f);
        platformFlip = false;//----------------The platform is not flipped 
        effector.rotationalOffset = 0;//--The collidable surface of the platform is set to it's default angle, 0 degrees
        gameObject.layer = 10;//----------The platform's layer is set to #10 (NotYetDroppable) which is designated as ground, allowing the character to stand on it
    }
    private void Update()
    {
        if (pmov.lookDown && groundCheck.grounded)//If the character is looking down and grounded
        {
            if (Input.GetButtonDown("Jump"))//----If the player presses the jump button
            {
                StartCoroutine("DropThrough");
                DropThrough ();
            }
        }

        if (!groundCheck.grounded && pmov.rising && !platformFlip)//-----If the character is rising and the platform is not flipped
            gameObject.layer = 11;//--------------The platform's layer is set to #11 ("droppable") which is not designated as ground, this prevents the idle animation from playing when the character is dropping through the platform


            if (!pmov.rising && !platformFlip)//if the character is not rising and the platform is not flipped
            {
            effector.rotationalOffset = 0;//--The collidable surface of the platform is set to it's default angle, 0 degrees
            gameObject.layer = 10;//----------The platform's layer is set to #10 (NotYetDroppable) which is designated as ground, allowing the character to stand on it
        }
    }
}
