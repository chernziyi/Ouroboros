using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public static bool upgradeTime = false;
    public GameObject upgradeMenuUI;
    public GameObject upgradeManager;

    public GameObject u1;
    public GameObject u2;
    public GameObject u3;

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpgradeMenuEnter()
    {
        upgradeTime = true;
        Time.timeScale = 0f;
        upgradeMenuUI.SetActive(true);

        u1.GetComponent<UpgradeDisplay>().NewUpgrade();
        u2.GetComponent<UpgradeDisplay>().NewUpgrade();
        u3.GetComponent<UpgradeDisplay>().NewUpgrade();
    }

    public void UpgradeMenuExit()
    {
        upgradeTime = false;
        Time.timeScale = 1f;
        upgradeMenuUI.SetActive(false);
    }
}
