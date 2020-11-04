using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DroppablePlatformCheck : MonoBehaviour
{
    public bool touchingDroppablePlatform;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("MakeshiftGround") || other.CompareTag("MovingPlatform") || other.CompareTag("ClosestMovingPlatform"))
            touchingDroppablePlatform = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("MakeshiftGround") || other.CompareTag("MovingPlatform") || other.CompareTag("ClosestMovingPlatform"))
            touchingDroppablePlatform = false;
    }
}
