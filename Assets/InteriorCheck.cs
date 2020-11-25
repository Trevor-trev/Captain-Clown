using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorCheck : MonoBehaviour
{
    public bool isOutside;
    public bool inHouse1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "House 1")
        {
            isOutside = false;
            inHouse1 = true;
        }
        if (other.gameObject.name == "Outdoors")
        {
            isOutside = true;
            inHouse1 = false;
        }
    }
}
