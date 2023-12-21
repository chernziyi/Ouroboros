using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime;
    public float speed;

    private GameObject weaponUser;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        weaponUser = GameObject.FindGameObjectWithTag("Player");

        if (weaponUser.GetComponent<PlayerAttack>().weaponUsed == 1)
        {
            damage = weaponUser.GetComponent<WeaponDatabase>().damage[weaponUser.GetComponent<PlayerAttack>().Weapon1 - 1];
        }
        else if (weaponUser.GetComponent<PlayerAttack>().weaponUsed == 2)
        {
            damage = weaponUser.GetComponent<WeaponDatabase>().damage[weaponUser.GetComponent<PlayerAttack>().Weapon2 - 1];
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
