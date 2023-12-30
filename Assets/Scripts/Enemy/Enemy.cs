using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float poisonStack;
    [SerializeField] private float poisonDPS;
    [SerializeField] private float poisonDuration;
    private float pTimer;
    private float pCount;

    public float soulDrop;
    [SerializeField] GameObject soul;

    public GameObject upgradeManager;

    private void Start()
    {
        upgradeManager = GameObject.FindGameObjectWithTag("UpgradeManager");
        pCount = poisonDuration;
    }

    private void Update()
    {
        poisonDPS = upgradeManager.GetComponent<UpgradeProcessor>().poisonDPSFinal;
        poisonDuration = upgradeManager.GetComponent<UpgradeProcessor>().poisonDurationFinal;

        if (poisonStack > 0)
        {
            if(pCount <= 0)
            {
                poisonStack -= 1;
                pCount = poisonDuration;
            }
            else
            {
                if (pTimer <= 0)
                {
                    pCount -= 1;
                    pTimer = 1;
                    TakeDamage(poisonDPS);
                }
                else
                {
                    pTimer -= Time.deltaTime;
                }
            }
        }
    }

    public void TakePoison(float poisonStackInflicted)
    {
        poisonStack = poisonStackInflicted;
        pCount = poisonDuration;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            for(int i = 0; i < soulDrop; i++)
            {
                Instantiate(soul, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Debug.Log("KO!");
        }
    }

}
