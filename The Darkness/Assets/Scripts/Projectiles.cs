using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
   
    public PlayerSpells currentSpell;
    public PlayerSpells impact, fireball, dart, poisionDart;

    public void Start()
    {
        if (gameObject.tag == "IO")
        {
            currentSpell = impact;
        }
        if (gameObject.tag == "D")
        {
            currentSpell = dart;
        }
        if (gameObject.tag == "PD")
        {
            currentSpell = poisionDart;
        }
        if (gameObject.tag == "FB")
        {
            currentSpell = fireball;
        }
        StartCoroutine(DestroyProjectile());
    }

    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.transform.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(currentSpell.damage);
            print(currentSpell.damage);
            GameObject effect = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Obstical" || collision.gameObject.tag == "Chest" || collision.gameObject.tag == "BP")
        {
            GameObject effect1 = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect1, 5f);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Crystal")
        {
            CrystalHealth crystalHealth = collision.transform.GetComponent<CrystalHealth>();
            crystalHealth.TakeDamage(currentSpell.damage);
            GameObject effect2 = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect2, 5f);
            Destroy(gameObject);
        } 
    }   

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(currentSpell.lifetime);
        GameObject effect3 = Instantiate(currentSpell.destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect3, 5f);
        Destroy(gameObject);
    }
}
