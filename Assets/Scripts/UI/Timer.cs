using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TargetCounter targetCounter;
    public Text timerText;

    public string secondsLeftKey = "SecondsLeft";

    public float secondsLeft = 36000;
    public float savedSecondsLeft;
    public float secondsCount;
    
    public int minuteCount;
    public int hourCount;

    public bool newRecordSet;

    private void Start()
    {
        savedSecondsLeft = PlayerPrefs.GetFloat(secondsLeftKey, 0);
        newRecordSet = false;
    }
    void FixedUpdate()
    {
        UpdateTimerUI();

        if (!targetCounter.brokeAllTargets)
            secondsLeft -= Time.fixedDeltaTime;
    }
    public void UpdateTimerUI()
    {
        if (!targetCounter.brokeAllTargets)
        {
            secondsCount += Time.fixedDeltaTime;
        }
        if (targetCounter.brokeAllTargets)
#pragma warning disable CS1717 // Assignment made to same variable
            secondsCount = secondsCount;
#pragma warning restore CS1717 // Assignment made to same variable

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

    private void Update()
    {
        if (targetCounter.brokeAllTargets)
        {
            if (savedSecondsLeft < secondsLeft)
            {
                newRecordSet = true;
                savedSecondsLeft = secondsLeft;
                PlayerPrefs.SetFloat(secondsLeftKey, savedSecondsLeft);
            }


        }
    }

}
