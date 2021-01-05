using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GemHolderCheck gemHolderCheck;

    public bool hasBlueGem;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Blue Gem")
        {
            hasBlueGem = true;         
        }
    }

    private void Update()
    {
        if (gemHolderCheck.placingBlueGem)
            hasBlueGem = false;
    }
}
