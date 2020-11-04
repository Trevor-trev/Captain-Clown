using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Top Speed change to 55
public class MovingPlatformCheck : MonoBehaviour
{
    public Playermovement pmov;
    public bool onMovingPlatform;
    public Rigidbody2D rb;
    public GameObject player;
    public PogoController pogo;
    public PlatformDrop platformDropV;
    public PlatformDrop platformDropH;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
            other.gameObject.tag = "ClosestMovingPlatform";
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClosestMovingPlatform"))
        {
            if (!pmov.rising && !(platformDropV.platformFlip || platformDropH.platformFlip))
            {
                onMovingPlatform = true;
                if (pmov.xdirection == 0 || !pogo.onPogo)
                {
                    rb.isKinematic = true;
                    player.transform.parent = other.transform;
                }
            }
        }

        if (other.gameObject.CompareTag("ClosestMovingPlatform") && (platformDropH.platformFlip || platformDropV.platformFlip))
        {
            other.gameObject.tag = "MovingPlatform";
            onMovingPlatform = false;
            rb.isKinematic = false;
            player.transform.parent = null;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClosestMovingPlatform"))
        {
            other.gameObject.tag = "MovingPlatform";
            onMovingPlatform = false;
            rb.isKinematic = false;
            player.transform.parent = null;           
        }
    }

    void Update()
    {
        if (pmov.xdirection != 0 || pogo.onPogo)
        {
            rb.isKinematic = false;
            player.transform.parent = null;
        }
    }
}
