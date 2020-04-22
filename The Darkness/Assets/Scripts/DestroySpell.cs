using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpell : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("Hit player");
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
