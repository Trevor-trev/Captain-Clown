using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPlatformDirectionChange : MonoBehaviour
{
    public VPlatformMovement vPlatformMove;
    public bool moveDown;
    public bool moveUp;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform") || other.CompareTag("ClosestMovingPlatform"))
        {
            if (vPlatformMove.movingDown)
            {
                moveUp = true;
                moveDown = false;
            }

            if (vPlatformMove.movingUp)
            {
                moveUp = false;
                moveDown = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MovingPlatform") || other.CompareTag("ClosestMovingPlatform"))
        {
            moveUp = false;
            moveDown = false;
        }
    }
}
