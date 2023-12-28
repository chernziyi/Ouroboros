using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;

    public TextMeshProUGUI upgradeName;
    public TextMeshProUGUI description;

    public Image artwork;

    // Update is called once per frame
    void Update()
    {
        upgradeName.text = upgrade.upgradeName;
        description.text = upgrade.description;
        artwork.sprite = upgrade.artwork;
    }
}
