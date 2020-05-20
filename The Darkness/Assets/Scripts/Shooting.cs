using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public PlayerSpells currentSpell;
    public PlayerSpells impact, fireball, dart, poisionDart;
    public Transform firePoint;
    public bool canFire;
    
    public float magicForce = 20f;
    

    public void Start()
    {
        canFire = true;
        currentSpell = impact;        
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire1") && canFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canFire = false;
        GameObject magic = Instantiate(currentSpell.spell, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * magicForce, ForceMode2D.Impulse);
        StartCoroutine(fireRate());
        
    }
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("PD"))
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
    
    IEnumerator fireRate()
    {
        yield return new WaitForSeconds(0.35f);
        canFire = true;

    }
}
