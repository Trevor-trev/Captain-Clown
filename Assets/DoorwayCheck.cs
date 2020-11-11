using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayCheck : MonoBehaviour
{
    public GroundCheck groundCheck;
    public Playermovement pmov;
    public bool inDoorway = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClosestOpenDoorway"))
            inDoorway = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OpenDoorway"))
            inDoorway = false;
    }
}
