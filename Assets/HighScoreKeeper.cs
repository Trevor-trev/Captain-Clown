using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreKeeper : MonoBehaviour
{
    public Timer timer;
    public TargetCounter targetCounter;

    public Text bestTime;

    string bestTimeKey = "BestTime";

    public Inventory inventory;


    private void Start()
    {
        bestTime.text = PlayerPrefs.GetString(bestTimeKey, "0h:0m:0s");
    }

    void Update()
    {
        if (targetCounter.brokeAllTargets)
        {
            if (timer.newRecordSet)
            {
                bestTime.text = timer.timerText.text;
                PlayerPrefs.SetString(bestTimeKey, timer.timerText.text);
                PlayerPrefs.Save();
            }
        }

    }
}
