using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    float timeBtwAttacks;
    [HideInInspector] public float weaponUsed; // 1 or 2

    public int Weapon1;
    public int Weapon2;
    private float attackSpeed;
    private float DPS;
    private float atkDuration;

    private bool attacking = false;
    float atkTime;
    [SerializeField] private int comboMeter;
    public float comboDuration;
    float ctimer;
    bool combo;

    public GameObject upgradeManager;
    public WeaponDatabase weaponDatabase;

    [SerializeField] private Transform shotPoint;
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject projectile;

    private void Start()
    {
        Weapon1 = 3; // we cannot use 0 due to animation stuff.
        Weapon2 = 2;
        combo = true;
    }

    private void Update()
    {
        if (Time.timeScale > 0f)
        {
            if (timeBtwAttacks <= 0)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    if (weaponUsed == 2)
                    {
                        comboMeter = 0;
                    }

                    weaponUsed = 1;

                    if (comboMeter < weaponDatabase.combo[Weapon1 - 1])
                    {
                        comboMeter += 1;
                    }
                    else
                    {
                        comboMeter = 1;
                    }

                    DPS = weaponDatabase.DPS[Weapon1 - 1];
                    if (comboMeter == 1)
                    {
                        attackSpeed = weaponDatabase.c1AttackSpeed[Weapon1 - 1];
                        atkDuration = weaponDatabase.c1AttackDuration[Weapon1 - 1];
                    }
                    else if (comboMeter == 2)
                    {
                        attackSpeed = weaponDatabase.c2AttackSpeed[Weapon1 - 1];
                        atkDuration = weaponDatabase.c2AttackDuration[Weapon1 - 1];
                    }

                    anim.SetInteger("Weapon", Weapon1);
                    timeBtwAttacks = attackSpeed;
                    atkTime = atkDuration;
                    ctimer = comboDuration;
                    anim.SetInteger("Combo", comboMeter);

                    if (weaponDatabase.ranged[Weapon1 - 1] == true)
                    {
                        Instantiate(projectile, shotPoint.position, weapon.rotation);
                        Debug.Log("Fire");
                    }

                }
                else if (Input.GetMouseButtonDown(1))
                {
                    if (weaponUsed == 1)
                    {
                        comboMeter = 0;
                    }

                    anim.SetInteger("Weapon", Weapon2);
                    weaponUsed = 2;

                    if (comboMeter < weaponDatabase.combo[Weapon2 - 1])
                    {
                        comboMeter += 1;
                    }
                    else
                    {
                        comboMeter = 1;
                    }

                    DPS = weaponDatabase.DPS[Weapon2 - 1];
                    if (comboMeter == 1)
                    {
                        attackSpeed = weaponDatabase.c1AttackSpeed[Weapon2 - 1];
                        atkDuration = weaponDatabase.c1AttackDuration[Weapon2 - 1];
                    }
                    else if (comboMeter == 2)
                    {
                        attackSpeed = weaponDatabase.c2AttackSpeed[Weapon2 - 1];
                        atkDuration = weaponDatabase.c2AttackDuration[Weapon2 - 1];
                    }

                    anim.SetInteger("Weapon", Weapon2);
                    timeBtwAttacks = attackSpeed;
                    atkTime = atkDuration;
                    ctimer = comboDuration;
                    anim.SetInteger("Combo", comboMeter);

                    if (weaponDatabase.ranged[Weapon2 - 1] == true)
                    {
                        Instantiate(projectile, shotPoint.position, weapon.rotation);
                        Debug.Log("Fire");
                    }
                }
            }
            else
            {

                anim.SetInteger("Weapon", 0); //to actually trigger the damn thing like i swear to fucking god
                anim.SetInteger("Combo", 0);
                timeBtwAttacks -= Time.deltaTime;
            }
        }

        if (atkTime > 0)
        {
            attacking = true;
            atkTime -= Time.deltaTime;
        }
        else
        {
            attacking = false;
        }

        if (ctimer > 0)
        {
            combo = true;
            ctimer -= Time.deltaTime;
        }
        else
        {
            combo = false;
            comboMeter = 0;
            anim.SetInteger("Combo", comboMeter);
        }

        anim.SetBool("InCombo", combo);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (attacking == true)
            {
                other.GetComponent<Enemy>().TakeDamage(Mathf.Round(DPS * atkDuration));

                if (upgradeManager.GetComponent<UpgradeDatabase>().level[0] >= 3)
                {
                    other.GetComponent<Enemy>().TakePoison(2);
                }else if (upgradeManager.GetComponent<UpgradeDatabase>().level[0] >= 1)
                {
                    other.GetComponent<Enemy>().TakePoison(1);
                }
            }
        }
    }
}