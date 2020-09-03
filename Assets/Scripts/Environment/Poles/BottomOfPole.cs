using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomOfPole : MonoBehaviour
{
    Playermovement pmov;
    void Start()
    {
        pmov = FindObjectOfType<Playermovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)//Execute this code when the specified object enters a trigger placed at the bottom of the pole
    {
        if (other.CompareTag("Player"))//When an object tagged "Player" reaches the bottom of the pole
            pmov.onPole = false;//------Make the character let go of the pole
    }

    private void OnTriggerStay2D(Collider2D other)//Execute this code when the specified object enters a trigger placed at the bottom of the pole
    {
        if (other.CompareTag("Player"))//When an object tagged "Player" reaches the bottom of the pole
            pmov.onPole = false;//------Make the character let go of the pole
    }
}
