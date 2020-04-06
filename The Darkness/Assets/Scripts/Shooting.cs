using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject magicPrefab;

    public float magicForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject magic = Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * magicForce, ForceMode2D.Impulse);
    }
}
