using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTrophyDisplay : MonoBehaviour
{
    public Inventory inventory;

    public GameObject bronzeTrophy;
    public GameObject silverTrophy;
    public GameObject goldTrophy;
    public GameObject platinumTrophy;
    public GameObject DiamondTrophy;

    private void Update()
    {
        if (inventory.hasBronzeTrophy)
            bronzeTrophy.SetActive(true);

        if (inventory.hasSilverTrophy)
            silverTrophy.SetActive(true);

        if (inventory.hasGoldTrophy)
            goldTrophy.SetActive(true);

        if (inventory.hasPlatinumTrophy)
            platinumTrophy.SetActive(true);

        if (inventory.hasDiamondTrophy)
            DiamondTrophy.SetActive(true);
    }
}
