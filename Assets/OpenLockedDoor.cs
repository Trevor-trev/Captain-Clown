using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public BoxCollider2D doorCollider;
    private SpriteRenderer sprite;
    public BlueGemHolder blueGemHolder;
    public Animator animator;
    public GameObject doorOpenSound;

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
    void PlayOpeningSound()
    {
        Instantiate(doorOpenSound, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (!blueGemHolder.locked)
            animator.SetBool("IsOpening", true);
    }
}

