using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public PlayerSpells currentSpell;
    public PlayerSpells impact, fireball, dart, poisionDart;
    public Transform firePoint;
    
    public float magicForce = 20f;
    

    public void Start()
    {
        currentSpell = impact;        
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject magic = Instantiate(currentSpell.spell, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * magicForce, ForceMode2D.Impulse);
    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PD"))
        {
            currentSpell = poisionDart;
        }
        if (collision.CompareTag("FB"))
        {
            currentSpell = fireball;
        }
        if (collision.CompareTag("IO"))
        {
            currentSpell = impact;
        }
        if (collision.CompareTag("D"))
        {
            currentSpell = dart;
        }
    }
    
}
