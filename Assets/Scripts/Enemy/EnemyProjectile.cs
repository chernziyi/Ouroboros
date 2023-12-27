using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime;
    public float speed;
    public float damage;

    public bool homing;
    private Transform playerPosH; // for homing

    // Start is called before the first frame update
    void Start()
    {
        playerPosH = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 difference = playerPosH.position - transform.position; //non homing shite
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    void Update()
    {
        if (homing == true)
        {
            Vector3 difference = playerPosH.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
            transform.position = Vector2.MoveTowards(transform.position, playerPosH.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
