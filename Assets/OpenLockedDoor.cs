using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public BoxCollider2D doorCollider;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void DisableCollider()
    {
        doorCollider.enabled = false;
        sprite.sortingLayerName = "Pole";
    }
}

