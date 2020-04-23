using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerInteraction : MonoBehaviour
{
    //Chest System
    public GameObject chestClosed, chestOpen, player;
    public Light2D chestLights;
   
    public GameObject[] Spells;   

    public void Start()
    {
        chestClosed.SetActive(true);
        chestOpen.SetActive(true);

        chestLights.GetComponent<Light>();
        chestLights.intensity = 1.75f;
    }
    //Chest System
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
                GameObject mySpells = Spells[Random.Range(0, Spells.Length)];
                Instantiate(mySpells, transform.position, Quaternion.identity);
            }
        }
    }
}
