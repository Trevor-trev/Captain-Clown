using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomOfPole : MonoBehaviour
{
    PoleClimbController poleClimb;
    void Start()
    {
        poleClimb = FindObjectOfType<PoleClimbController>();
    }

    private void OnTriggerEnter2D(Collider2D other)//Execute this code when the specified object enters a trigger placed at the bottom of the pole
    {
        if (other.CompareTag("Player"))//When an object tagged "Player" reaches the bottom of the pole
            poleClimb.onPole = false;//------Make the character let go of the pole
        Debug.Log("Inside Pole Release");
    }

    private void OnTriggerStay2D(Collider2D other)//Execute this code when the specified object enters a trigger placed at the bottom of the pole
    {
        Debug.Log("Inside Pole Release");
        if (other.CompareTag("Player"))//When an object tagged "Player" reaches the bottom of the pole
            poleClimb.onPole = false;//------Make the character let go of the pole
    }
}
