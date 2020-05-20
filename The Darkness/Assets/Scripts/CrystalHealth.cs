using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class CrystalHealth : MonoBehaviour
{
    public float health = 2000f;
    public Light2D crystalLight;
    public Light2D globalLight;
    public Light2D churchLight;
    public GameObject boss;
    public GameObject e1, e2, e3, e4, e5, e6, e7, e8;

    public void Start()
    {
        crystalLight.GetComponent<Light>();
        globalLight.GetComponent<Light>();
        churchLight.GetComponent<Light>();

        crystalLight.intensity = 1f;
        globalLight.intensity = 1f;

        boss.SetActive(false);
        e1.SetActive(false);
        e2.SetActive(false);
        e3.SetActive(false);
        e4.SetActive(false);
        e5.SetActive(false);
        e6.SetActive(false);
        e7.SetActive(false);
        e8.SetActive(false);
    }

    public void Update()
    { 
        if(health > 1500)
        {
            crystalLight.intensity = 1f;
            globalLight.intensity = 1f;
            churchLight.intensity = 1f;
        }
        else if(health > 1000)
        {
            e1.SetActive(true);
            e2.SetActive(true);
            crystalLight.intensity = 0.75f;
            globalLight.intensity = 0.75f;
            churchLight.intensity = 0.75f;
        }
        else if(health > 500)
        {
            e3.SetActive(true);
            e4.SetActive(true);
            e5.SetActive(true);
            crystalLight.intensity = 0.5f;
            globalLight.intensity = 0.5f;
            churchLight.intensity = 0.5f;
        }
        else if(health > 250)
        {
            boss.SetActive(true);
            e6.SetActive(true);
            e7.SetActive(true);
            e8.SetActive(true);
            crystalLight.intensity = 0.25f;
            globalLight.intensity = 0.25f;
            churchLight.intensity = 0.25f;
        }
        else if (health < 0)
        {
            crystalLight.intensity = 0f;
            globalLight.intensity = 0f;
            churchLight.intensity = 0f;
            Destroy(gameObject);
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
