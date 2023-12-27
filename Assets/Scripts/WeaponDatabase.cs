using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    [HideInInspector] public string[] weaponName;
    [HideInInspector] public bool[] ranged;
    [HideInInspector] public float[] combo; // 1 if none
    [HideInInspector] public float[] DPS; //per atkDur for melee, per shot for ranged
    [HideInInspector] public float[] c1AttackSpeed;
    [HideInInspector] public float[] c1AttackDuration;
    [HideInInspector] public float[] c2AttackSpeed;
    [HideInInspector] public float[] c2AttackDuration;

    private void Start()
    {
        weaponName = new string[] { "Fist", "Gun", "Sword" };
        ranged = new bool[] { false, true, false };
        combo = new float[] { 2, 1, 1 };
        DPS = new float[] { 50, 20, 66 };
        c1AttackSpeed = new float[] { 0.2f, 1f, 0.5f };
        c1AttackDuration = new float[] { 0.1f, 0f, 0.15f };
        c2AttackSpeed = new float[] { 0.5f, 0f, 0f };
        c2AttackDuration = new float[] { 0.3f, 0f, 0f };
    }
}