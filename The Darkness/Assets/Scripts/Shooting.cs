using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public PlayerSpells Currentspell;

    public PlayerSpells impact, fireball, dart, poisionDart;


    public Transform firePoint;
    public GameObject magicPrefab;

    public float magicForce = 20f;

    public void Start()
    {
        Currentspell = impact;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject magic = Instantiate(Currentspell.spell, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * magicForce, ForceMode2D.Impulse);
    }   
}
