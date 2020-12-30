using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
    /*This script is to be placed on an object that gets destroyed after one hit. originally meant as a placeholder enemy*/
{
    public TargetCounter targetCounter;

    public int health = 1;//-------------The health of the object 

    public GameObject targetBreak;//-----A game object with an explosion animation

    public void TakeDamage (int damage)//A function which causes the objects health to decrease
    {
        health -= damage;//--------------Decrease the objects health according to the damage variable in the bullet script

        if (health <= 0)//---------------If the objects health is less than or equal to 0
            Die();//---------------------Execute the Die function
    }

    void Die()//------------------------------------------------------------A fuction to be executed when the objects health reaches or falls below 0
    {
        Instantiate(targetBreak, transform.position, Quaternion.identity);//Place the death effect prefab where the object is
        Destroy(gameObject);//----------------------------------------------Remove the object from the scene
        targetCounter.targetsLeft -= 1;
    }
}
