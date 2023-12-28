using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeName;
    public string description;
    public string rarity;
    public int level;

    public Sprite artwork;

    public string effect;
}
