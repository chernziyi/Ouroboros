using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeProcessor : MonoBehaviour
{
    [SerializeField] private float poisonDPS;
    [SerializeField] private float poisonDuration;
    public float poisonDPSFinal;
    public float poisonDurationFinal;

    public GameObject upgradeManager;

    private void Update()
    {
        if (upgradeManager.GetComponent<UpgradeDatabase>().level[0] >= 2)
        {
            poisonDPSFinal = poisonDPS + 3;
            poisonDurationFinal = poisonDuration * 2;
        }
        else
        {
            poisonDPSFinal = poisonDPS;
            poisonDurationFinal = poisonDuration;
        }

        if (upgradeManager.GetComponent<UpgradeDatabase>().level[7] == 1)
        {
            poisonDPSFinal = poisonDPSFinal * 2;
        }
        else if (upgradeManager.GetComponent<UpgradeDatabase>().level[7] == 2)
        {
            poisonDPSFinal = poisonDPSFinal * 4;
        }
        else if (upgradeManager.GetComponent<UpgradeDatabase>().level[7] == 3)
        {
            poisonDPSFinal = poisonDPSFinal * 8;
        }
        else if (upgradeManager.GetComponent<UpgradeDatabase>().level[7] == 4)
        {
            poisonDPSFinal = poisonDPSFinal * 16;
        }
    }
}