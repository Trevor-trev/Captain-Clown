using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneBottom : MonoBehaviour
{
    public bool moveDown;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            moveDown = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            moveDown = false;
    }
}
