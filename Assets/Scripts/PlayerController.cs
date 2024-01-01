using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float health;
    public float invFrames;
    private float invTimer;

    public Rigidbody2D rb;

    Vector2 movement; //direction. You learned Physics, muffin...

    //input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(invTimer > 0)
        {
            invTimer -= Time.deltaTime;
        }
    }

    //movement
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        if(invTimer <= 0)
        {
            health -= damage;
            Debug.Log("OW!");
            invTimer = invFrames;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
