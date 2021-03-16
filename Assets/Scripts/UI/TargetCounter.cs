using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCounter : MonoBehaviour
{
    public int targetsLeft;
    public Text targetsLeftDisplay;

    public bool brokeAllTargets;
    void Start()
    {
        targetsLeft = 50;
        brokeAllTargets = false;
    }

    void Update()
    {
        targetsLeftDisplay.text = " = " + targetsLeft.ToString();

        if (targetsLeft == 0)
            brokeAllTargets = true;

    }
}
