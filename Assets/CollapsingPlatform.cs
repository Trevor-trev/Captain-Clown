
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;

public class CollapsingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool touchingFloor;
    public bool touchingCeiling;
    public bool playerOn;
    public bool moveUp;
    public float speed = 5f;

    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CollapsingPlatformCeiling"))
            touchingCeiling = true;

        if (other.gameObject.CompareTag("CollapsingPlatformFloor"))                    
            touchingFloor = true;

        if (other.gameObject.CompareTag("Player"))
            playerOn = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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

        if (other.gameObject.CompareTag("Player"))           
            playerOn = false;
    }

    private void Update()
    {
        if (moveUp)
            rb.velocity = new Vector2(0, speed);
        if (!moveUp)
            rb.velocity = new Vector2(0, 0);

        if (!touchingCeiling  && !touchingFloor)
        {
            rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;

            if (!playerOn)
                moveUp = true;

            if (playerOn)
                moveUp = false;
        }

        if (touchingCeiling)
        {
            moveUp = false;

            if (playerOn)
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            if (!playerOn)
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (touchingFloor)
        {
            if (playerOn){
                moveUp = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;}
            if (!playerOn){
                rb.constraints = ~RigidbodyConstraints2D.FreezePositionY;
                moveUp = true;}
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