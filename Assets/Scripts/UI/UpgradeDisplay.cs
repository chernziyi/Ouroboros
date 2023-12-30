using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;
    public Upgrade loading;
    public GameObject upgradeManager;
    public GameObject upgradeMenu;

    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI description;

    public int upgradeSlotID;

    public Image artwork;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeSelect()
    {
        upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] += 1;
        upgradeMenu.GetComponent<UpgradeMenu>().UpgradeMenuExit();
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

        if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] >= 3)
        {
            upgradeName.text = loading.upgradeName;
            artwork.sprite = loading.artwork;
        }
        else
        {
            upgradeName.text = upgrade.upgradeName;
            artwork.sprite = upgrade.artwork;
        }

        if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] == 0)
        {
            description.text = upgrade.lvl1Description;
        }else if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] == 1)
        {
            description.text = upgrade.lvl2Description;
        }else if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] == 2)
        {
            description.text = upgrade.lvl3Description;
        }else if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] == 3)
        {
            description.text = upgrade.lvl4Description;
        }else if (upgradeManager.GetComponent<UpgradeDatabase>().level[upgrade.ID] >= 3)
        {
            description.text = loading.lvl1Description;
        }
    }
}
