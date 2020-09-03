using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletR : MonoBehaviour
    /*This script is to be placed on a bullet prefab which also has a collider set as a trigger*/
{
    public float speed = 20.5f;//------------------------The speed of the bullet
    public int damage = 100;//---------------------------The damage dealt by the bullet

    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Animator animator;

    void Start()
    {
        rb.velocity = transform.right * speed;//---------Move the bullet away from its firepoint according to the speed variable
        Physics.IgnoreLayerCollision(14, 12);//----------Don't allow collisions with between objects on layers 14 and 12 (bullet and camera, respectively)
    }

    private void OnTriggerEnter2D(Collider2D hit)//------Execute when the specified objects come into contact with this object's trigger collider
    {
        if (hit.CompareTag("Target"))//------------------If the object is tagged "Target"
        {
            Target target = hit.GetComponent<Target>();//Create a reference to the Target class, name it target, and when an object enters the trigger try to locate a Target script on said object
            Destroy(gameObject);//-----------------------Remove the bullet from the scene

            if (target != null)//------------------------If there is a Target script on the object that was hit
                target.TakeDamage(damage);//-------------Execute the damage function on the object that was hit


            Instantiate(impactEffect, transform.position, transform.rotation);//Place the impactEffect prefab where the bullet hit
        }

       if (hit.CompareTag("Solid") || hit.CompareTag("Slope"))//----------------If the object that enter's the trigger is tagged as "Solid" or "Slope"
        {
            Destroy(gameObject);//----------------------------------------------Remove the bullet from the scene
            Instantiate(impactEffect, transform.position, transform.rotation);//Place the impactEffect prefab where the bullet hit
        }

    }
}
