using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDestruction : MonoBehaviour
{
    public GameObject hitEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hit, 5f);
        Destroy(gameObject);
    }
}
