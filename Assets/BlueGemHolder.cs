using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemHolder : MonoBehaviour
{
    public Inventory inventory;
    public bool locked;
    public bool unlockDoor;

    private void Start()
    {
        locked = true;
    }

    IEnumerator UnlockDoor()
    {
        unlockDoor = true;
        yield return new WaitForSeconds(.1f);
        locked = false;
        unlockDoor = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {           
            if (inventory.hasBlueGem)
            {
                StartCoroutine(UnlockDoor());
            }                
        }           
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.tag = "ClosestGemHolder";
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            gameObject.tag = "GemHolder";
    }
    void Update()
    {

    }
}
