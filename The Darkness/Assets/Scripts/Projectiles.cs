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
        StartCoroutine(DestroyProjectile());
    }    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(currentSpell.damage);
            GameObject effect = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Obstical" || collision.gameObject.tag == "Chest")
        {
            GameObject effect1 = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect1, 5f);
            Destroy(gameObject);
        }
 
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PD"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentSpell = poisionDart;
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("FB"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentSpell = fireball;
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("IO"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentSpell = impact;
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("D"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentSpell = dart;
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(currentSpell.lifetime);
        GameObject effect2 = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect2, 5f);
        Destroy(gameObject);
    }
}
