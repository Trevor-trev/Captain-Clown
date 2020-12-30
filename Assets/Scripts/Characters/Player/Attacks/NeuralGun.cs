using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NeuralGun : MonoBehaviour
    /*This script is to be placed on the player character*/
{
    public Playermovement pmov;
    public GroundCheck groundCheck;
    public LedgeClimb ledgeClimb;
    public PogoController pogo;
    public PoleClimbController poleClimb;
    public Animator animator;
    public DoorwayCheck doorwayCheck;

    public GameObject neuralBullet;

    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointRight;
    public Transform firePointLeft;

    public bool aimUp = false;
    public bool aimDown = false;
    public bool shoot;
    public bool stopMovement;
    
    



    IEnumerator Shoot()//----------------------------A coroutine labeled "Shoot". Has the ability to pause and resume execution according to specifications
    {
        stopMovement = true;
        yield return new WaitForFixedUpdate();
        animator.SetBool("IsShooting", true);//------------------------------------------Set the IsShooting animation parameter to true
        shoot = true;//------------------------------------------------------------------Set the shoot bool to true
        yield return new WaitForSeconds(.15f);//-----------------------------------------Pause execution for .15 seconds

        if (pmov.facingRight && !(aimUp || aimDown))  //----------------------------------If the character is facing right and not aiming up or down 
            Instantiate(neuralBullet, firePointRight.position, firePointRight.rotation);//Create a bullet from the FirePointRight gameobject              

        if (pmov.facingLeft && !(aimUp || aimDown))//-------------------------------------If the character is facing left and not aiming up or down
            Instantiate(neuralBullet, firePointLeft.position, firePointLeft.rotation);//--Create a bullet from the FirePointLeft gameobject

        if (aimUp)//----------------------------------------------------------------------If the character is aiming up
            Instantiate(neuralBullet, firePointUp.position, firePointUp.rotation);//------Create a bullet from the FirePointUp gameobject

        if (aimDown && (!groundCheck.grounded || poleClimb.onPole))//---------------------If the character is aiming down and either is not grounded or is on a pole
            Instantiate(neuralBullet, firePointDown.position, firePointDown.rotation);//--Create a bullet from the FirePointDown gameobject

        yield return new WaitForSeconds(.07f);//------------------------------------------Pause execution for .07 seconds

        animator.SetBool("IsShooting", false);//------------------------------------------Set the IsShooting animator parameter to false
        shoot = false;//------------------------------------------------------------------Set the shoot bool to false

        aimUp = false;//------------------------------------------------------------------Set the aimUp bool to false
        animator.SetBool("IsAimingUp", false);//------------------------------------------Set the IsAimingUp animator parameter to false

        aimDown = false;//----------------------------------------------------------------Set the aimDown bool to false
        animator.SetBool("IsAimingDown", false);//----------------------------------------Set the IsAimingDown animator parameter to false
        stopMovement = false;
    }

    private void Update()
    {
        if (aimUp)//----------------------------------------------------------------------If the character is aiming up
            animator.SetBool("IsAimingUp", true);//---------------------------------------Set the IsAimingUp animation parameter to true

        if (aimDown)//--------------------------------------------------------------------If the character is aiming down
            animator.SetBool("IsAimingDown", true);//-------------------------------------Set the IsAimingDown animation parameter to false

        if (!shoot && Input.GetButton("LookUp")){//---------------------------------------If the character is not shooting and the player presses the LookUp button
            aimUp = true;//---------------------------------------------------------------Set the aimUp bool to true
            aimDown = false;}//-----------------------------------------------------------Set the aimDown bool to false

        if (!shoot && Input.GetButton("LookDown")){//-------------------------------------If the character is not shooting and the player presses the LookDown button
            aimDown = true;//-------------------------------------------------------------Set the aimDown bool to true
            aimUp = false;}//-------------------------------------------------------------Set the aimUp bool to false

        if (!shoot && Input.GetButtonUp("LookUp")){//--------------------------------------If the character is not shooting and the player releases the LookUp button        
            aimUp = false;//---------------------------------------------------------------Set the aimUp bool to false;
            animator.SetBool("IsAimingUp", false);}//--------------------------------------Set the IsAimingUp animation parameter to false
        

        if (!shoot && Input.GetButtonUp("LookDown")){//------------------------------------If the character is not shooting and the player releases the LookDown button
            aimDown = false;//-------------------------------------------------------------Set the aimDown bool to false;
            animator.SetBool("IsAimingDown", false);}//------------------------------------Set the IsAimingDown animation parameter to false

        if (!(ledgeClimb.ledgeClimb || ledgeClimb.ledgeHang) && !(groundCheck.grounded && pmov.lookDown) && !shoot && !pogo.onPogo && !doorwayCheck.walkingThroughDoor && Input.GetButtonDown("Shoot"))//If the character is not climbing or hanging from a ledge, is not shooting, is not on the pogo, and the player presses the Shoot button                               
            StartCoroutine("Shoot");//-----------------------------------------------------Start the Shoot coroutine
       
        if (pmov.falling && pmov.lookDown && !poleClimb.onPole)//-----------------------If the character is falling and looking down and not on a pole
            neuralBullet.GetComponent<BulletR>().speed += 12.5f * Time.deltaTime;//-----Increase the bullet speed over time so that the falling character doesn't catch up with it
        else//--------------------------------------------------------------------------Otherwise
            neuralBullet.GetComponent<BulletR>().speed = 20.5f;//-----------------------Set the bullet speed at it's default, static speed
    }
}