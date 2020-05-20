using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public void Update()
    {
        if(health > 100)
        {
            health = 100;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("25"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                health += 25f;
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("50"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                health += 50f;
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
