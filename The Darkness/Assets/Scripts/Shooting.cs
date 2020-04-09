using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject magicPrefab;

    public GameObject shield;

    public float magicForce = 20f;

    public void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            shield.SetActive(true);
        }

        if (Input.GetButtonUp("Fire2"))
        {
            shield.SetActive(false);            
        }      
    }

    void Shoot()
    {
        GameObject magic = Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * magicForce, ForceMode2D.Impulse);
    }   
}
