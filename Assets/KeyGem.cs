﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGem : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inventory"))
            Destroy(gameObject);
    }
}