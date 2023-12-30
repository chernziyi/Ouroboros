using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string rarity;
    public int ID;

    public string lvl1Description;
    public string lvl2Description;
    public string lvl3Description;
    public string lvl4Description;

    public Sprite artwork;
}
