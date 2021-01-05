using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite collectedSprite;
    public Rigidbody2D rb;
    public float speed;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inventory"))
            StartCoroutine(Collected());
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = collectedSprite;
        rb.velocity = new Vector2(0, speed * Time.deltaTime);
    }
    IEnumerator Collected()
    {
        ChangeSprite();
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
