using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCounter : MonoBehaviour
{
    public int targetsLeft;
    public Text targetsLeftDisplay;
    void Start()
    {
        targetsLeft = 25;
    }

    void Update()
    {
        targetsLeftDisplay.text = " = " + targetsLeft.ToString();
    }
}
