using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCounter : MonoBehaviour
{
    public int targetsLeft;
    public Text targetCount;
    void Start()
    {
        targetsLeft = 25;
    }

    void Update()
    {
        targetCount.text = " = " + targetsLeft.ToString();
    }
}
