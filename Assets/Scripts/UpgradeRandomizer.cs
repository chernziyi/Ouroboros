using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRandomizer : MonoBehaviour
{
    [SerializeField] private int cWeight;
    [SerializeField] private int ucWeight;
    [SerializeField] private int rWeight;
    [SerializeField] private int lWeight;

    public string currentUpgrade;

    public string[] cUpgrades;
    public string[] ucUpgrades;
    public string[] rUpgrades;
    public string[] lUpgrades;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomUpgrade();
        }
    }

    public void RandomUpgrade()
    {
        int rarity = Random.Range(1, cWeight + ucWeight + rWeight + lWeight + 1);

        if (rarity <= cWeight)
        {
            Debug.Log("Common");
            //common upgrade
        }
        else if (rarity <= ucWeight + cWeight && rarity > cWeight)
        {
            Debug.Log("Uncommon");
            //uncommon upgrade
        }
        else if (rarity <= ucWeight + cWeight + rWeight && rarity > ucWeight + cWeight)
        {
            Debug.Log("Rare");
            //rare upgrade
        }
        else if (rarity <= ucWeight + cWeight + rWeight + lWeight && rarity > ucWeight + cWeight + rWeight)
        {
            Debug.Log("Legendary");
            //legendary upgrade
        }
    }
}
