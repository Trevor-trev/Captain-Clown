using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    public bool itemGrabbed;

    IEnumerator GrabItem()
    {
        itemGrabbed = true;
        yield return new WaitForEndOfFrame();
        itemGrabbed = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            StartCoroutine("GrabItem");
            GrabItem();
        }
    }

    private void Update()
    {
        if (itemGrabbed == true)
            Debug.Log("Item Grabbed");
    }
}
