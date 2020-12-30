using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasBlueGem;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Blue Gem")
        {
            hasBlueGem = true;
            Debug.Log("yep");
        }
    }
}
