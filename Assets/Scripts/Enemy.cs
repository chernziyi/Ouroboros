using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;

    public float soulDrop;
    [SerializeField] GameObject soul;

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
