using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayCheck : MonoBehaviour
{
    public GroundCheck groundCheck;
    public Playermovement pmov;
    public PogoController pogo;
    public NeuralGun neuralGun;

    public bool inDoorway = false;
    public bool walkingThroughDoor = false;


    IEnumerator WalkingThroughDoor()
    {
        walkingThroughDoor = true;
        yield return new WaitForSeconds(.75f);
        walkingThroughDoor = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClosestOpenDoorway"))
            inDoorway = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OpenDoorway") || other.gameObject.CompareTag("ClosestOpenDoorway"))
            inDoorway = false;
    }

    private void Update()
    {
        if (pmov.horizontalMove == 0 && inDoorway && !pogo.onPogo && !neuralGun.shoot && Input.GetButton("LookUp"))
            StartCoroutine("WalkingThroughDoor");
    }
}
