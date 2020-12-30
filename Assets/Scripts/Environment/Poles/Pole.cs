using UnityEngine;

public class Pole : MonoBehaviour
{
    /*To be attached a gameobject, set as a child of the player. The gameobject could be titled "PoleCheck", tagged as "Player", and on the "Player" layer.
    The PoleCheck object should have a trigger collider on it, placed on the players head.
    This script does two things:
    -Allows the player to walk off the pole when their feet are close to the ground
    -Makes sure that the when the player tries to climb a pole, the character sticks to the correct one
    (For convenience, make the pole a prefab)*/   
    public GroundCheck groundCheck;
    public PogoController pogo;
    public PoleClimbController poleClimb;

    public bool nextToPole;
    public bool makeshiftGrounded = false;//-When both of these makeshiftGrounds are true, the character is able to walk off of the pole by moving left or right.
    public bool makeshiftGrounded2 = false;//The trigger colliders that are linked to these variables should be positioned so that when the character is activating both of them, their feet are touching or close to the ground

    private void OnTriggerEnter2D(Collider2D other)//Execute this code when the character enters the specified trigger collider which is attached to the pole
    {
       
        if (other.CompareTag("Pole")){//------------If the character enters the trigger of an object tagged as "Pole"
            nextToPole = true;
            other.gameObject.tag = "ClosestPole";}//Change that objects tag to "ClosestPole" to specify which pole the character should grab onto
    }
    private void OnTriggerStay2D(Collider2D other)//Execute this code when the character is sitting inside the specified colliders
    {
        
        if (other.CompareTag("MakeshiftGround"))//--This box collider sits above a ground tile that has a pole going through it
            makeshiftGrounded = true;//-------------Set to true when the character is in the "above the ground" collider

        if (other.CompareTag("MakeshiftGround2"))//-Another box collider that sits level with the ground tile that has a pole going through it
            makeshiftGrounded2 = true;//------------Set to true when the character is in the "level with the ground" collider

        if (other.CompareTag("ClosestPole"))
        {
            nextToPole = true;

            if (!pogo.onPogo)//-----------------------If the character is not on the pogo stick
            {
                if (groundCheck.grounded)//-----------If the character is grounded
                    if (poleClimb.verticalMove != 0)//Grab the pole if the player presses the up or down buttons
                        poleClimb.onPole = true;
                if (!groundCheck.grounded)//----------If the character is not grounded
                    if (poleClimb.verticalMove > 0)//-If the player presses the up button
                        poleClimb.onPole = true;//----Grab onto the pole
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)//-----------------------Execute this code when the character leaves the specified colliders
    {
        if (other.CompareTag("MakeshiftGround"))
            makeshiftGrounded = false;//-----------------------------------Set to false when the character leaves the "above the ground" collider

        if (other.CompareTag("MakeshiftGround2"))
            makeshiftGrounded2 = false;//----------------------------------Set to false when the character leaves the "level with the ground" collider

        if (other.CompareTag("ClosestPole")){//-----------------------------If the exited trigger is on an object designated as "ClosestPole"
            nextToPole = false;
            other.gameObject.tag = "Pole";}//-------------------------------Change the tag for that object to "Pole" in order to recognize that that pole is no longer close enough to interact with
        
        if (GameObject.FindGameObjectsWithTag("ClosestPole").Length == 0)//When the character is not close to any poles
            poleClimb.onPole = false;//------------------------------------Make sure the character does not go senile and grab onto an imaginary pole 
    }
}

