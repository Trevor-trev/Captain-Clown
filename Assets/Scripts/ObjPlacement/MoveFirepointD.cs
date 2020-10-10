using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFirepointD : MonoBehaviour
{
    public Playermovement pmov;
    public PoleClimbController poleClimb;
    Vector2 firePointDPosition;

    private void Start()
    {
        firePointDPosition = gameObject.transform.localPosition;
    }
    private void Update()
    {
        if (poleClimb.onPole)
        {
            if (pmov.facingRight)
                firePointDPosition.x = -.55f;

            if (pmov.facingLeft)
                firePointDPosition.x = .305f;
        }
            
        if (!poleClimb.onPole)
                firePointDPosition.x = -.172f;

            transform.localPosition = firePointDPosition;
        
    }
}

