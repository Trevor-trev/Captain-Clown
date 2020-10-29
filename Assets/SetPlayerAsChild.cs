using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerAsChild : MonoBehaviour
{

    public Playermovement pmov;
    public bool onMovingPlatform;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            onMovingPlatform = true;
            if (pmov.xdirection == 0)
            {                
                GetComponent<Rigidbody2D>().isKinematic = true;
                transform.parent = collision.transform;
            }
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
            onMovingPlatform = false;
    }*/void Update()
    {
        onMovingPlatform = false;
        if (pmov.xdirection != 0)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            transform.parent = null;
        }
    }
}
