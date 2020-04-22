using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public PlayerSpells currentSpell;
    public PlayerSpells impact, fireball, dart, poisionDart;

    public void Start()
    {
        currentSpell = impact;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(currentSpell.damage);            
        }
    }
   
}
