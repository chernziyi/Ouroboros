using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private bool attacking = false;
    [SerializeField] private Animator anim;
    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attacking = anim.GetBool("Rush");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (attacking == true)
            {
                other.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
    }
}
