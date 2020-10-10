 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFirePointU : MonoBehaviour
{
    public Playermovement pmov;
    public PoleClimbController poleClimb;
    Vector2 firePointUPosition;

    private void Start()
    {
        firePointUPosition = gameObject.transform.localPosition;
    }
    private void Update()
    {
        if (poleClimb.onPole)
        {
            if (pmov.facingRight)
                firePointUPosition.x = -.624f;

            if (pmov.facingLeft)
                firePointUPosition.x = .115f;
        }

        if (!poleClimb.onPole)
            firePointUPosition.x = -.034f;

        transform.localPosition = firePointUPosition;
        
    }
}
