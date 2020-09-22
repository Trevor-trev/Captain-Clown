using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerLayerChangeInSecrets : MonoBehaviour
{

    public bool insideSecret;
    public void OnTriggerStay2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            insideSecret = true;           
    }

    public void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            insideSecret = false;
    }
}
