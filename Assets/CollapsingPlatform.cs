
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;

public class CollapsingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    public Playermovement pmov;
    public PlatformDrop platformDrop;

    public bool touchingFloor;
    public bool touchingCeiling;
    public bool playerOn;
    public bool moveUp;
    public bool moveDown;
    public float risingSpeed;
    public float fallingSpeed;
    public float fallSpeedStart;
    public float fallSpeedIncrement;

    void Start()
    {
        platformDrop = gameObject.GetComponent<PlatformDrop>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollapsingPlatformCeiling"))
            touchingCeiling = true;

        if (other.gameObject.CompareTag("CollapsingPlatformFloor"))
            touchingFloor = true;

        if (other.gameObject.CompareTag("PlatformCheck"))
            playerOn = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlatformCheck"))
        {
            playerOn = true;
            moveUp = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollapsingPlatformCeiling"))
            touchingCeiling = false;

        if (other.gameObject.CompareTag("CollapsingPlatformFloor"))
            touchingFloor = false;

        if (other.gameObject.CompareTag("PlatformCheck"))
            playerOn = false;
    }

    private void Update()
    {
        if (!moveDown)
            fallingSpeed = fallSpeedStart;

        if (moveDown)
            rb.velocity = new Vector2(0, -1 * (fallingSpeed += fallSpeedIncrement));

        if (moveUp)
            rb.velocity = new Vector2(0, risingSpeed);

        if (!moveUp && !moveDown)
            rb.velocity = new Vector2(0, 0);

        if (!touchingCeiling && !touchingFloor)
        {       
            if (playerOn && !pmov.rising)
            {
                moveUp = false;
                moveDown = true;
            }
        }

            if (touchingCeiling)
            {
                moveUp = false;

                if (playerOn && !pmov.rising)
                    moveDown = true;

                if (!playerOn)
                    moveDown = false;
            }

            if (touchingFloor)
            {
                moveDown = false;

                if (playerOn /*&& !pmov.isJumping*/)  
                    moveUp = false;

                if (!playerOn)                                          
                        moveUp = true;                
            }        
    }
}









/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
        if (other.gameObject.CompareTag("CollapsingPlatformStopper"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;       
    }
        private void OntriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && (other.gameObject.CompareTag("CollapsingPlatformStopper")))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;        
    }*/