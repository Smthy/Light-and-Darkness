using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{

    public GameObject chestClosed, chestOpen, player;   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("E has been clicked");
                chestClosed.SetActive(false);
            }            
        }
    }
}
