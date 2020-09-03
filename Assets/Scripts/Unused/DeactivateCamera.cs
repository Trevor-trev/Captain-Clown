using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCamera : MonoBehaviour
{
    public GroundCheck groundCheck;
    public Playermovement pmov;

    void Update()
    {
        if (groundCheck.grounded)
            gameObject.SetActive(false);
    }
}
