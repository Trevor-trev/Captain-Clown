using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorway : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.tag = "ClosestOpenDoorway";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.tag = "OpenDoorway";
    }
}
