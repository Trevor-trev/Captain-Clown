using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoTriggerEnabler : MonoBehaviour
{
    BoxCollider2D bounceTrigger;
    public PogoController pogo;
    public SlopeCheck slopeCheck;
    public Rigidbody2D rb;   

    private void Start()
    {
        bounceTrigger = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (slopeCheck.bouncing && Input.GetButtonDown("Pogo"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 12.5f);
        }
    }
    private void LateUpdate()
    {
        if (pogo.onPogo)
            bounceTrigger.enabled = true;
        else if (!pogo.onPogo)
            bounceTrigger.enabled = false;
    }

}
