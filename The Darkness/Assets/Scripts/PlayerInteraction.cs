using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //Chest System
    public GameObject chestClosed, chestOpen, player;
    public GameObject[] Spells;


    public void Start()
    {
        chestClosed.SetActive(true);
        chestOpen.SetActive(true);
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
                Debug.Log("E has been clicked");
                GameObject mySpells = Spells[Random.Range(0, Spells.Length)];
                Instantiate(mySpells, transform.position, Quaternion.identity);
            }
        }
    }
}
