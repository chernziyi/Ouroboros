using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRandomizer : MonoBehaviour
{
    [SerializeField] private int cWeight;
    [SerializeField] private int rWeight;
    [SerializeField] private int eWeight;
    [SerializeField] private int lWeight;

    public string currentUpgrade1;
    public string currentUpgrade2;
    public string currentUpgrade3;

    public string[] cUpgrades;
    public string[] rUpgrades;
    public string[] eUpgrades;
    public string[] lUpgrades;

    public GameObject upgradeMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpgradeMenu(3);
        }
    }

    public void UpgradeMenu(int slots)
    {
        for (int i = 0; i < slots; i++)
        {
            RandomUpgrade(i + 1);
        }

        upgradeMenu.GetComponent<UpgradeMenu>().UpgradeMenuEnter();
    }

    public void RandomUpgrade(int slot)
    {
        int rarity = Random.Range(1, cWeight + rWeight + eWeight + lWeight + 1);
        
        if (rarity <= cWeight)
        {
            Debug.Log("Common");

            if (slot == 1)
            {
                currentUpgrade1 = cUpgrades[Random.Range(0, cUpgrades.Length)];
            }
            else if (slot == 2)
            {
                currentUpgrade2 = cUpgrades[Random.Range(0, cUpgrades.Length)];
                if (currentUpgrade2 == currentUpgrade1)
                {
                    RandomUpgrade(2);
                }
            }
            else if (slot == 3)
            {
                currentUpgrade3 = cUpgrades[Random.Range(0, cUpgrades.Length)];
                if ((currentUpgrade3 == currentUpgrade1) || (currentUpgrade3 == currentUpgrade2))
                {
                    RandomUpgrade(3);
                }
            }
        }
        else if (rarity <= rWeight + cWeight && rarity > cWeight)
        {
            Debug.Log("Rare");
            if (slot == 1)
            {
                currentUpgrade1 = rUpgrades[Random.Range(0, rUpgrades.Length)];
            }
            else if (slot == 2)
            {
                currentUpgrade2 = rUpgrades[Random.Range(0, rUpgrades.Length)];
                if (currentUpgrade2 == currentUpgrade1)
                {
                    RandomUpgrade(2);
                }
            }
            else if (slot == 3)
            {
                currentUpgrade3 = rUpgrades[Random.Range(0, rUpgrades.Length)];
                if ((currentUpgrade3 == currentUpgrade1) || (currentUpgrade3 == currentUpgrade2))
                {
                    RandomUpgrade(3);
                }
            }
        }
        else if (rarity <= rWeight + cWeight + eWeight && rarity > rWeight + cWeight)
        {
            Debug.Log("Epic");
            if (slot == 1)
            {
                currentUpgrade1 = eUpgrades[Random.Range(0, eUpgrades.Length)];
            }
            else if (slot == 2)
            {
                currentUpgrade2 = eUpgrades[Random.Range(0, eUpgrades.Length)];
                if (currentUpgrade2 == currentUpgrade1)
                {
                    RandomUpgrade(2);
                }
            }
            else if (slot == 3)
            {
                currentUpgrade3 = eUpgrades[Random.Range(0, eUpgrades.Length)];
                if ((currentUpgrade3 == currentUpgrade1) || (currentUpgrade3 == currentUpgrade2))
                {
                    RandomUpgrade(3);
                }
            }
        }
        else if (rarity <= rWeight + cWeight + eWeight + lWeight && rarity > rWeight + cWeight + eWeight)
        {
            Debug.Log("Legendary");
            if (slot == 1)
            {
                currentUpgrade1 = lUpgrades[Random.Range(0, lUpgrades.Length)];
            }
            else if (slot == 2)
            {
                currentUpgrade2 = lUpgrades[Random.Range(0, lUpgrades.Length)];
                if (currentUpgrade2 == currentUpgrade1)
                {
                    RandomUpgrade(2);
                }
            }
            else if (slot == 3)
            {
                currentUpgrade3 = lUpgrades[Random.Range(0, lUpgrades.Length)];
                if ((currentUpgrade3 == currentUpgrade1) || (currentUpgrade3 == currentUpgrade2))
                {
                    RandomUpgrade(3);
                }
            }
        }

    }
}
