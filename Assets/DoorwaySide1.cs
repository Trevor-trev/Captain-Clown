﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwaySide1 : MonoBehaviour
{
    public GameObject player;
    public GameObject otherSideOfDoor;
    public Animator animator;
    public Playermovement pmov;
    public DoorwayCheck doorwayCheck;

    public bool inDoorway;
    public bool walkingThroughDoor;
    public bool warped;
    public bool arrived = false;

    IEnumerator WalkThroughDoor()
    {
        walkingThroughDoor = true;
        animator.SetBool("WalkingThroughDoor", true);
        yield return new WaitForSeconds(0.67f);
        animator.SetBool("WalkingThroughDoor", false);
        player.transform.position = otherSideOfDoor.transform.position;
        warped = true;
        walkingThroughDoor = false;
        yield return new WaitForSeconds(.2f);
        warped = false;
    }

    IEnumerator Arrived()
    {
        arrived = true;
        yield return new WaitForSeconds(.2f);
        arrived = false;
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        otherSideOfDoor = transform.parent.GetChild(1).gameObject;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DoorwayCheck"))
        {
            gameObject.tag = "ClosestOpenDoorway";
            inDoorway = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DoorwayCheck"))
        {
            gameObject.tag = "OpenDoorway";
            inDoorway = false;
            arrived = false;
        }
    }
    private void FixedUpdate()
    {
 
        if (pmov.xdirection == 0 && inDoorway && doorwayCheck.inDoorway && Input.GetButton("LookUp"))
            StartCoroutine("WalkThroughDoor");

        if (otherSideOfDoor.GetComponent<DoorwaySide2>().warped)
            StartCoroutine("Arrived");
    }
}
