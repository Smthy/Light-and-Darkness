using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject death;

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
        GameObject effect = Instantiate(death, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
