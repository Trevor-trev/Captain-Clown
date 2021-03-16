using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyDisplay : MonoBehaviour
{

    public Inventory inventory;

    public Image bronzeTrophy;
    public Image silverTrophy;
    public Image goldTrophy;
    public Image platinumTrophy;
    public Image diamondTrophy;

    public GameObject bronzeFader;
    public GameObject silverFader;
    public GameObject goldFader;
    public GameObject platinumFader;
    public GameObject diamondFader;

    void Update()
    {
        if (inventory.hasBronzeTrophy)
        {
            bronzeFader.SetActive(false);
            bronzeTrophy.color = Color.white;
        }

        if (inventory.hasSilverTrophy)
        {
            silverFader.SetActive(false);
            silverTrophy.color = Color.white;
        }

        if (inventory.hasGoldTrophy)
        {
            goldFader.SetActive(false);
            goldTrophy.color = Color.white;
        }

        if (inventory.hasPlatinumTrophy)
        {
            platinumFader.SetActive(false);
            platinumTrophy.color = Color.white;
        }

        if (inventory.hasDiamondTrophy)
        {
            diamondFader.SetActive(false);
            diamondTrophy.color = Color.white;
        }

    }
}
