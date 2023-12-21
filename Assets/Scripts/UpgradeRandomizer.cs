using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRandomizer : MonoBehaviour
{
    [SerializeField] private int cWeight;
    [SerializeField] private int ucWeight;
    [SerializeField] private int rWeight;
    [SerializeField] private int lWeight;

    public string currentUpgrade1;
    public string currentUpgrade2;
    public string currentUpgrade3;

    public string[] cUpgrades;
    public string[] ucUpgrades;
    public string[] rUpgrades;
    public string[] lUpgrades;

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
    }

    public void RandomUpgrade(int slot)
    {
        int rarity = Random.Range(1, cWeight + ucWeight + rWeight + lWeight + 1);

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
        else if (rarity <= ucWeight + cWeight && rarity > cWeight)
        {
            Debug.Log("Uncommon");
            if (slot == 1)
            {
                currentUpgrade1 = ucUpgrades[Random.Range(0, ucUpgrades.Length)];
            }
            else if (slot == 2)
            {
                currentUpgrade2 = ucUpgrades[Random.Range(0, ucUpgrades.Length)];
                if (currentUpgrade2 == currentUpgrade1)
                {
                    RandomUpgrade(2);
                }
            }
            else if (slot == 3)
            {
                currentUpgrade3 = ucUpgrades[Random.Range(0, ucUpgrades.Length)];
                if ((currentUpgrade3 == currentUpgrade1) || (currentUpgrade3 == currentUpgrade2))
                {
                    RandomUpgrade(3);
                }
            }
        }
        else if (rarity <= ucWeight + cWeight + rWeight && rarity > ucWeight + cWeight)
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
        else if (rarity <= ucWeight + cWeight + rWeight + lWeight && rarity > ucWeight + cWeight + rWeight)
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
