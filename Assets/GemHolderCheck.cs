using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemHolderCheck : MonoBehaviour
{
    public Inventory inventory;
    public bool placingBlueGem;

    IEnumerator PlacingBlueGem()
    {
        placingBlueGem = true;
        yield return new WaitForSeconds(.1f);
        placingBlueGem = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ClosestGemHolder"))
        {
            Debug.Log("gemholdercheck");
            if (inventory.hasBlueGem)
            {
                StartCoroutine(PlacingBlueGem());
            }
        }
            
    }
}
