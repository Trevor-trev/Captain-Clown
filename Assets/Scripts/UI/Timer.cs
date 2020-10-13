﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TargetCounter targetCounter;
    public Text timerText;
    public float secondsCount;
    public int minuteCount;
    public int hourCount;
    void FixedUpdate()
    {
        UpdateTimerUI();
    }
    public void UpdateTimerUI()
    {
        if (targetCounter.targetsLeft > 0)
            secondsCount += Time.fixedDeltaTime;
        else
            secondsCount = secondsCount;
        
        timerText.text = hourCount + "h:" + minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount %= 60;
            if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount %= 60;
            }
        }
    }
    }