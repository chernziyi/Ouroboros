using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime;
    public float speed;

    public GameObject weaponUser;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        if(weaponUser.GetComponent<PlayerAttack>().weaponUsed == 1)
        {
            damage = weaponUser.GetComponent<WeaponDatabase>().damage[weaponUser.GetComponent<PlayerAttack>().Weapon1];
        }
        else
        {
            damage = weaponUser.GetComponent<WeaponDatabase>().damage[weaponUser.GetComponent<PlayerAttack>().Weapon2];
        }
        Invoke("SelfDestruct", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
