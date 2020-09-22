using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetHitSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string helmetHit;

    public Playermovement pmov;

    private void Update()
    {
        if (pmov.touchingCeiling)
            FMODUnity.RuntimeManager.PlayOneShot(helmetHit);
    }
}
