using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlatfomMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public PlatformDirectionChange directionChangeToR;
    public PlatformDirectionChange directionChangeToL;
    public float platformSpeed = 5f;
    public bool movingRight;
    public bool movingLeft;

    private void Start()
    {
        rb.velocity = new Vector2(platformSpeed, 0);
        movingRight = true;
    }
    void Update()
    {
        if (directionChangeToR.moveRight)
        {
            rb.velocity = new Vector2(platformSpeed, 0);
            movingRight = true;
            movingLeft = false;
            animator.SetBool("MovingRight", true);
            animator.SetBool("MovingLeft", false);
        }

        if (directionChangeToL.moveLeft)
        {
            rb.velocity = new Vector2(platformSpeed * -1, 0);
            movingRight = false;
            movingLeft = true;
            animator.SetBool("MovingRight", false);
            animator.SetBool("MovingLeft", true);
        }
    }
}
