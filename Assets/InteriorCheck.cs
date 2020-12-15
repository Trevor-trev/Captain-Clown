using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorCheck : MonoBehaviour
{
    public bool isOutside;
    public bool inHouse1;
    public bool inSlugTemple;
    public bool inHouse2;
    public bool inHouse3;
    public bool inJailCell;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "House 1")
        {
            isOutside = false;
            inHouse1 = true;
            inSlugTemple = false;
            inHouse2 = false;
        }
        if (other.gameObject.name == "Outdoors")
        {
            isOutside = true;
            inHouse1 = false;
            inSlugTemple = false;
            inHouse2 = false;
        }
        if (other.gameObject.name == "Slug Temple")
        {
            isOutside = false;
            inHouse1 = false;
            inSlugTemple = true;
            inHouse2 = false;
        }
        if (other.gameObject.name == "House 2")
        {
            isOutside = false;
            inHouse1 = false;
            inSlugTemple = false;
            inHouse2 = true;
        }
    }
}
