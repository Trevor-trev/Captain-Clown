using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerChange : MonoBehaviour
{
    //TO BE ATTACHED TO THE PLAYER CHARACTER

    /*This script changes the character's sorting order depending on which way the character is facing
      to keep their sprite from looking funny when standing next to a wall
      This will only work if the character is on the default layer
      and the wall is on the default layer with it's default sorting order set to 2
      This is only relavent if the game is in a tilted, "2.5D" perspective
      much like Commander Keen, in which these scripts were originally intended to mimic.*/

    public LedgeClimb ledgeClimb;
    public PlayerLayerChangeInSecrets inSecret;
    public Playermovement pmov;
    private SpriteRenderer sprite;//--------------------------A reference to the sprite renderer on the same object that this script is attached to
    private bool dontChangeLayer;//---------------------------A bool that determines when to change the player's sorting layer
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    IEnumerator JumpedFromPole()//----------------------------A coroutine labeled "JumpedFromPole". Has the ability to pause and resume execution according to specifications
    {
        dontChangeLayer = true;//-----------------------------Dont change the player's layer yet    
        yield return new WaitForSeconds(1);//-----------------Wait for the specified time (in seconds)
        dontChangeLayer = false;//----------------------------Change the player's layer
    }
    void Update()
    {
        
        if (pmov.jumpedFromPole){//---------------If the character has jumped from a pole
            JumpedFromPole();
            StartCoroutine("JumpedFromPole");}//--Start the jumped from pole coroutine

        if (pmov.facingRight && !pmov.onPole)//---If the character is facing right while not on a pole
            sprite.sortingOrder = 1;//------------Set the character's order within it's current layer to 1

        if (pmov.facingLeft && !pmov.onPole && !inSecret.insideSecret)//----If the character is facing left while not on a pole
            sprite.sortingOrder = 3;//------------Set the character's order within it's current layer to 3

        if (pmov.onPole || dontChangeLayer)//------------------------If the character is on a pole
            sprite.sortingLayerName = "Pole";//---Set the character's sorting layer to "Pole"

        if (!pmov.onPole && !dontChangeLayer)//-----------------------If the character is not on a pole
            sprite.sortingLayerName = "Default";//Set the character's sorting layer to "Default"

        if (inSecret.insideSecret)
            sprite.sortingOrder = 1;

        if (ledgeClimb.ledgeHang || ledgeClimb.ledgeClimb)
            sprite.sortingOrder = 0;
    }
}
