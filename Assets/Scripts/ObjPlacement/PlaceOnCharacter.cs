using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnCharacter : MonoBehaviour
{
    //This script places whatever game object it's attached to a the same position of whichever game object you designate as "gameObj"

    public Transform gameObj;// The game object that you wish for the game object with this script to overlap with
    void Start()
    {
        transform.position = new Vector3(gameObj.position.x, gameObj.position.y, gameObj.position.z);//Make sure the game object is at the same position as the character when the game starts
    }
    void Update()
    {
        transform.position = new Vector3(gameObj.position.x, gameObj.position.y, gameObj.position.z);//Make sure the game object is at the same position as the character every frame
    }
}
