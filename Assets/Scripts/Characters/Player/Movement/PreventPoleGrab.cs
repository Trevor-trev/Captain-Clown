using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventPoleGrab : MonoBehaviour
{
    public Playermovement pmov;

    public bool cannotGrabPole;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")/* && !pmov.onPole*/)
            cannotGrabPole = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*&& !pmov.onPole*/)
            cannotGrabPole = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || pmov.onPole)
            cannotGrabPole = false;
    }
}
