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

    public Transform destination;

    public GameObject player;

    public bool arrived;
    public bool inDoorway = false;
    public bool walkingThroughDoor = false;

    void Teleport()
    {
        player.transform.position = new Vector2(destination.transform.position.x, destination.transform.position.y);
    }

    IEnumerator WalkingThroughDoor()
    {
        walkingThroughDoor = true;
        yield return new WaitForSeconds(.7f);
        // player.transform.position = destination.transform.position;
        arrived = true;
        animator.SetBool("WalkingThroughDoor", false);
        walkingThroughDoor = false;
        yield return new WaitForSeconds(.25f);
        arrived = false;
        // changePosition = true;
        // yield return new WaitForEndOfFrame();
        // changePosition = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Doorway"))
        {
            inDoorway = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Doorway"))
        {
            inDoorway = true;
            destination = collision.transform.GetChild(0);
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
        if (inDoorway && Input.GetButtonDown("LookUp"))
        {
            animator.SetBool("WalkingThroughDoor", true);
            StartCoroutine(WalkingThroughDoor());
        }
    }

}



/*private void OnTriggerStay2D(Collider2D other)
{
    if (other.gameObject.CompareTag("ClosestOpenDoorway"))
        inDoorway = true;
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.gameObject.CompareTag("OpenDoorway") || other.gameObject.CompareTag("ClosestOpenDoorway"))
        inDoorway = false;
}

private void FixedUpdate()
{
    if (pmov.horizontalMove == 0 && inDoorway && !pogo.onPogo && !neuralGun.shoot && Input.GetButton("LookUp"))
        StartCoroutine(WalkingThroughDoor());
}*/