using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayCheck : MonoBehaviour
{
    public GroundCheck groundCheck;
    public Playermovement pmov;
    public PogoController pogo;
    public NeuralGun neuralGun;
    public Animator animator;
    public Doorway doorway;

    public Transform destination;

    public GameObject player;

    public bool goesToAboveDoorway;
    public bool arrived;
    public bool inDoorway = false;
    public bool walkingThroughDoor = false;

    IEnumerator TeleportPlayer()
    {
        player.transform.position = new Vector2(destination.transform.position.x, destination.transform.position.y);
        yield return new WaitForEndOfFrame();
        arrived = true;
    }

    IEnumerator FinishWalkingThroughDoor()
    {
        animator.SetBool("WalkingThroughDoor", false);
        walkingThroughDoor = false;
        yield return new WaitForSeconds(.25f);
        arrived = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Doorway"))
        {
            inDoorway = true;

            if (collision.GetComponent<Doorway>().goesToAbove == true)
                goesToAboveDoorway = true;
            if (collision.GetComponent<Doorway>().goesToAbove == false)
                goesToAboveDoorway = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Doorway"))
        {
            inDoorway = true;
            destination = collision.transform.GetChild(0);

            if (collision.GetComponent<Doorway>().goesToAbove == true)
                goesToAboveDoorway = true;
            if (collision.GetComponent<Doorway>().goesToAbove == false)
                goesToAboveDoorway = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Doorway"))
        {
            destination = null;
            inDoorway = false;
        }
    }

    private void Update()
    {
        if (neuralGun.shoot == false && inDoorway && Input.GetButtonDown("LookUp"))
        {
            animator.SetBool("WalkingThroughDoor", true);
            walkingThroughDoor = true;
        }
    }

}