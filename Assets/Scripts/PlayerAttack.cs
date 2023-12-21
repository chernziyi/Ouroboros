using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    float timeBtwAttacks;
    [SerializeField] float weaponUsed;

    public int Weapon1;
    [SerializeField] private float attackSpeed1;
    [SerializeField] private float weaponDamage1;
    [SerializeField] private float atkDuration1;

    public int Weapon2;
    [SerializeField] private float attackSpeed2;
    [SerializeField] private float weaponDamage2;
    [SerializeField] private float atkDuration2;

    [SerializeField] private bool attacking = false;
    float atkTime;

    public WeaponDatabase weaponDatabase;

    private void Start()
    {
        Weapon1 = 0; //0 is fist, default weapon
        Weapon2 = 0;
    }

    private void Update()
    {
        attackSpeed1 = weaponDatabase.attackSpeed[Weapon1];
        attackSpeed2 = weaponDatabase.attackSpeed[Weapon2];
        weaponDamage1 = weaponDatabase.damage[Weapon1];
        weaponDamage2 = weaponDatabase.damage[Weapon2];
        atkDuration1 = weaponDatabase.attackDuration[Weapon1];
        atkDuration2 = weaponDatabase.attackDuration[Weapon2];

        if (timeBtwAttacks <= 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetInteger("Weapon", Weapon1);
                timeBtwAttacks = attackSpeed1;
                atkTime = atkDuration1;
                weaponUsed = 1;

            } else if (Input.GetMouseButtonDown(1))
            {
                anim.SetInteger("Weapon", Weapon2);
                timeBtwAttacks = attackSpeed2;
                atkTime = atkDuration2;
                weaponUsed = 2;
            }
        } else
        {
            anim.SetInteger("Weapon", 0); //to actually trigger the damn thing like i swear to fucking god
            timeBtwAttacks -= Time.deltaTime;
        }

        if(atkTime > 0)
        {
            attacking = true;
            atkTime -= Time.deltaTime;
        }
        else
        {
            attacking = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            if(attacking == true)
            {
                if (weaponUsed == 1)
                {
                    other.GetComponent<Enemy>().TakeDamage(weaponDamage1);
                }
                else if (weaponUsed == 2)
                {
                    other.GetComponent<Enemy>().TakeDamage(weaponDamage2);
                }
                Debug.Log("Strike!");
            }
        }
    }

}

    
