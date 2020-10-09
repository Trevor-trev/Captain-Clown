using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoTriggerEnabler : MonoBehaviour
{
    BoxCollider2D bounceTrigger;
    public Playermovement pmov;

    private void Start()
    {
        bounceTrigger = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (pmov.pogo)
            bounceTrigger.enabled = true;
        else if (!pmov.pogo)
            bounceTrigger.enabled = false;
    }

}
