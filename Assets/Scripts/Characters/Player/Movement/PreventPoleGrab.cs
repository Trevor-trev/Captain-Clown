using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventPoleGrab : MonoBehaviour
{
    public PoleClimbController poleClimb;

    public bool cannotGrabPole;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            cannotGrabPole = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            cannotGrabPole = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || poleClimb.onPole)
            cannotGrabPole = false;
    }
}
