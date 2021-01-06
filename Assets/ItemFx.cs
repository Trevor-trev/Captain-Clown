using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFx : MonoBehaviour
{
   // public SpriteRenderer spriteRenderer;
    //public Sprite collectedSprite;
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    private void Start()
    {
        animator.SetBool("IsFlashing", true);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inventory"))
            StartCoroutine(Collected());
    }

    void ChangeSprite()
    {
        animator.SetBool("IsFlashing", false);
        animator.SetBool("IsCollected", true);
        //spriteRenderer.sprite = collectedSprite;
        rb.velocity = new Vector2(0, speed * Time.deltaTime);
    }
    IEnumerator Collected()
    {
        ChangeSprite();
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
