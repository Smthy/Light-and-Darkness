using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSystem : MonoBehaviour
{
    public GameObject chestClosed, chestOpen, player;   

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))  
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                chestClosed.SetActive(false);
                Debug.Log("E has been clicked");
            }                                        
        }
    }
}
