using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemHolder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Inventory inventory;
    public Animator animator;
    public PogoController pogo;

    public Sprite withGem;

    public bool locked;

    private void Start()
    {
        locked = true;
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = withGem;
    }
    IEnumerator UnlockDoor()
    {
        animator.SetBool("IsPlacingGem", true);
        yield return new WaitForSeconds(.1f);
        locked = false;
        ChangeSprite();
        yield return new WaitForSeconds(.1f);
        animator.SetBool("IsPlacingGem", false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {           
            if ((!pogo.onPogo) && inventory.hasBlueGem)
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
