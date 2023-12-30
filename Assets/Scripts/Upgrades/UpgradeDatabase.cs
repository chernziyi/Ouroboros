using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class UpgradeDatabase : MonoBehaviour
{
    public Upgrade[] Upgrade;
    public int[] level;

    private void Start()
    {
        for (int i = 0; i < level.Length; i++)
        {
            level[i] = 0;
        }
    }

}
