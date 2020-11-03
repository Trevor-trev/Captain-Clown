using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPlatformMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public VPlatformDirectionChange directionChangeToU;
    public VPlatformDirectionChange directionChangeToD;
    public float platformSpeed = 5f;
    public bool movingUp;
    public bool movingDown;

    private void Start()
    {
        rb.velocity = new Vector2(0, platformSpeed);
        movingUp = true;
    }

    void FixedUpdate()
    {
        if (directionChangeToU.moveUp)
        {
            rb.velocity = new Vector2(0, platformSpeed);
            movingUp = true;
            movingDown = false;
            animator.SetBool("MovingUp", true);
            animator.SetBool("MovingDown", false);
        }

        if (directionChangeToD.moveDown)
        {
            rb.velocity = new Vector2(0, platformSpeed * -1);
            movingUp = false;
            movingDown = true;
            animator.SetBool("MovingUp", false);
            animator.SetBool("MovingDown", true);
        }
    }
}
