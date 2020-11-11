using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwaySide1 : MonoBehaviour
{
    public GameObject player;
    public GameObject doorway2;
    public Animator animator;
    public bool inDoorway = false;
    public bool walkingThroughDoor;

    IEnumerator WalkThroughDoor()
    {
        walkingThroughDoor = true;
        animator.SetBool("WalkingThroughDoor", true);
        yield return new WaitForSeconds(0.67f);
        animator.SetBool("WalkingThroughDoor", false);
        player.transform.position = doorway2.transform.position;
        walkingThroughDoor = false;
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        doorway2 = transform.parent.GetChild(1).gameObject;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.tag = "ClosestOpenDoorway";
            inDoorway = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.tag = "OpenDoorway";
            inDoorway = false;
        }
    }
    private void Update()
    {
        if (inDoorway && Input.GetButtonDown("LookUp"))
            StartCoroutine("WalkThroughDoor");
    }
}
