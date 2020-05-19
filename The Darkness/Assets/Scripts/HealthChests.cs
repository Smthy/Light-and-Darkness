using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class HealthChests : MonoBehaviour
{
    public GameObject chestClosed, chestOpen, player;
    public Light2D chestLights;

    public GameObject[] heals;

    public void Start()
    {
        chestClosed.SetActive(true);
        chestOpen.SetActive(true);

        chestLights.GetComponent<Light>();
        chestLights.intensity = 1.75f;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chestClosed.SetActive(false);
                chestOpen.SetActive(false);

                chestLights.intensity = 0.5f;

                Debug.Log("E has been clicked");
                GameObject myHeals = heals[Random.Range(0, heals.Length)];
                Instantiate(myHeals, transform.position, transform.rotation);
            }
        }
    }
}
