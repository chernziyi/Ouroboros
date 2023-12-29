using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooter : MonoBehaviour
{
    public double souls;
    public double level;
    public GameObject upgradeManager;

    // Update is called once per frame
    void Update()
    {
        if (souls >= (level + 1) * (10 + (level + 2) * level))
        {
            souls -= (level + 1) * (10 + (level + 2) * level);
            level += 1;
            upgradeManager.GetComponent<UpgradeRandomizer>().LevelUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Loot")
        {
            other.GetComponent<Loot>().LootGet();
        }
    }

    public void SoulGet(float soulAmount)
    {
        souls += soulAmount;
    }
    
}
