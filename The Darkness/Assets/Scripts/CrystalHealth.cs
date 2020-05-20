using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CrystalHealth : MonoBehaviour
{
    public float health = 2000f;
    public Light2D crystalLight;
    public Light2D globalLight;
    public GameObject boss;
    public GameObject enemy;

    public void Start()
    {
        crystalLight.GetComponent<Light>();
        globalLight.GetComponent<Light>();

        crystalLight.intensity = 1f;
        globalLight.intensity = 1f;

        boss.SetActive(false);
    }

    public void Update()
    { 
        if(health > 1500)
        {
            crystalLight.intensity = 1f;
            globalLight.intensity = 1f;
        }
        else if(health > 1000)
        {
            crystalLight.intensity = 0.75f;
            globalLight.intensity = 0.75f;
        }
        else if(health > 500)
        {
            crystalLight.intensity = 0.5f;
            globalLight.intensity = 0.5f;
        }
        else if(health > 250)
        {
            boss.SetActive(true);
            crystalLight.intensity = 0.25f;
            globalLight.intensity = 0.25f;
        }
        else if (health < 0)
        {
            crystalLight.intensity = 0f;
            globalLight.intensity = 0f;
        }
    }

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
        Destroy(gameObject);
    }
}
