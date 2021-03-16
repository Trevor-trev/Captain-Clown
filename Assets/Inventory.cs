using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GemHolderCheck gemHolderCheck;
    public Timer timer;
    public TargetCounter targetCounter;

    public bool hasBlueGem;
    public bool hasBronzeTrophy;
    public bool hasSilverTrophy;
    public bool hasGoldTrophy;
    public bool hasPlatinumTrophy;
    public bool hasDiamondTrophy;

    public bool loseSilverTrophy;
    public bool loseGoldTrophy;
    public bool losePlatinumTrophy;
    public bool loseDiamondTrophy;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Blue Gem")
        {
            hasBlueGem = true;         
        }
    }

    private void Update()
    {

        if (timer.minuteCount == 3 && timer.secondsCount > 0)
            loseDiamondTrophy = true;

        if (timer.minuteCount == 4 && timer.secondsCount > 0)
            losePlatinumTrophy = true;

        if (timer.minuteCount == 5 && timer.secondsCount > 0)
            loseGoldTrophy = true;

        if (timer.minuteCount == 8 && timer.secondsCount > 0)
            loseSilverTrophy = true;

        if (gemHolderCheck.placingBlueGem)
            hasBlueGem = false;

        if (targetCounter.brokeAllTargets)
        {

            if ((timer.minuteCount == 8 && timer.secondsCount >= 1) || timer.minuteCount > 8)
                AwardBronze();

            if ((timer.minuteCount == 5 && timer.secondsCount >= 1) || timer.minuteCount == 8 && timer.secondsCount >= 0 && timer.secondsCount < 1)
                AwardSilver();

            if ((timer.minuteCount == 4 && timer.secondsCount >= 1) || timer.minuteCount == 5 && timer.secondsCount >= 0 && timer.secondsCount < 1)
                AwardGold();

            if ((timer.minuteCount == 3 && timer.secondsCount >= 1) || timer.minuteCount == 4 && timer.secondsCount >= 0 && timer.secondsCount < 1)
                AwardPlatinum();

            if ((timer.minuteCount < 3 && timer.secondsCount >= 0) || timer.minuteCount == 3 && timer.secondsCount == 0)
                AwardDiamond();
        }
    }

    public void AwardBronze()
    {
        hasBronzeTrophy = true;
        PlayerPrefs.Save();
    }

    public void AwardSilver()
    {
        hasSilverTrophy = true;
    }

    public void AwardGold()
    {
        hasGoldTrophy = true;
    }

    public void AwardPlatinum()
    {
        hasPlatinumTrophy = true;
    }

    public void AwardDiamond()
    {
        hasDiamondTrophy = true;
    }
}
