using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCamera : MonoBehaviour
{
    public GroundCheck groundCheck;
    public Playermovement pmov;

    void Update()
    {

        if (!groundCheck.grounded)
        {
            gameObject.SetActive(false);
            Debug.Log("yup");
        }
    }
}
