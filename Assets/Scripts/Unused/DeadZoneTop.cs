using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneTop : MonoBehaviour
{
    public bool moveUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            moveUp = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            moveUp = false;
    }
}
