using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;
    public GameObject upgradeManager;

    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI description;

    public int upgradeSlotID;

    public Image artwork;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewUpgrade()
    {
        if (upgradeSlotID == 1)
        {
            upgrade = upgradeManager.GetComponent<UpgradeRandomizer>().currentUpgrade1;
        }
        if (upgradeSlotID == 2)
        {
            upgrade = upgradeManager.GetComponent<UpgradeRandomizer>().currentUpgrade2;
        }
        if (upgradeSlotID == 3)
        {
            upgrade = upgradeManager.GetComponent<UpgradeRandomizer>().currentUpgrade3;
        }

        upgradeName.text = upgrade.upgradeName;
        description.text = upgrade.description;
        artwork.sprite = upgrade.artwork;
    }
}
