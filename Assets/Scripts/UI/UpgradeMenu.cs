using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenu : MonoBehaviour
{
    public static bool upgradeTime = false;
    public GameObject upgradeMenuUI;
    public GameObject upgradeManager;

    public GameObject u1Button;
    public GameObject u2Button;
    public GameObject u3Button;

    // Start is called before the first frame update
    void Start()
    {
        upgradeMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpgradeMenuEnter();
        }
    }

    public void UpgradeMenuEnter()
    {
        upgradeTime = true;
        Time.timeScale = 0f;
        upgradeMenuUI.SetActive(true);

    }
}
