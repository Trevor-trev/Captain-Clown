using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public BoxCollider2D doorCollider;
    private SpriteRenderer sprite;
    public BlueGemHolder blueGemHolder;
    public Animator animator;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        blueGemHolder = transform.GetChild(0).gameObject.GetComponent<BlueGemHolder>();
    }
    void DisableCollider()
    {
        doorCollider.enabled = false;
        sprite.sortingLayerName = "Pole";
    }

    private void Update()
    {
        if (!blueGemHolder.locked)
            animator.SetBool("IsOpening", true);

    }
}

