using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    float timeBtwAttacks;
    [HideInInspector] public float weaponUsed; // 1 or 2

    public int Weapon1;
    private float attackSpeed1;
    private float weaponDamage1;
    private float atkDuration1;

    public int Weapon2;
    private float attackSpeed2;
    private float weaponDamage2;
    private float atkDuration2;

    private bool attacking = false;
    float atkTime;

    public WeaponDatabase weaponDatabase;

    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject projectile;

    private void Start()
    {
        Weapon1 = 1; // we cannot use 0 due to animation stuff.
        Weapon2 = 2;
    }

    private void Update()
    {
        attackSpeed1 = weaponDatabase.attackSpeed[Weapon1 - 1];
        attackSpeed2 = weaponDatabase.attackSpeed[Weapon2 - 1];
        weaponDamage1 = weaponDatabase.damage[Weapon1 - 1];
        weaponDamage2 = weaponDatabase.damage[Weapon2 - 1];
        atkDuration1 = weaponDatabase.attackDuration[Weapon1 - 1];
        atkDuration2 = weaponDatabase.attackDuration[Weapon2 - 1];

        if (timeBtwAttacks <= 0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                anim.SetInteger("Weapon", Weapon1);
                timeBtwAttacks = attackSpeed1;
                atkTime = atkDuration1;
                weaponUsed = 1;

                if (weaponDatabase.ranged[Weapon1 - 1] == true)
                {
                    Instantiate(projectile, shotPoint.position, weapon.rotation);
                    Debug.Log("Fire");
                }

            } else if (Input.GetMouseButtonDown(1))
            {
                anim.SetInteger("Weapon", Weapon2);
                timeBtwAttacks = attackSpeed2;
                atkTime = atkDuration2;
                weaponUsed = 2;

                if (weaponDatabase.ranged[Weapon2 - 1] == true)
                {
                    Instantiate(projectile, shotPoint.position, weapon.rotation);
                    Debug.Log("Fire");
                }
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

    
