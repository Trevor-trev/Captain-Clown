using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDirectionChange : MonoBehaviour
{
    public HPlatfomMovement hPlatformMove;
    public bool moveLeft;
    public bool moveRight;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HMovingPlatform"))
        {
            if (hPlatformMove.movingRight) {
                moveRight = false;
                moveLeft = true;}

            if (hPlatformMove.movingLeft)
            {
                moveRight = true;
                moveLeft = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("HMovingPlatform"))
        {
            moveRight = false;
            moveLeft = false;
        }
    }
}
