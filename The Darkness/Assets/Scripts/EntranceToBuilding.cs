using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceToBuilding : MonoBehaviour
{
    public GameObject roof;

    public void Start()
    {
        roof.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roof.SetActive(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roof.SetActive(true);
        }
    }

}
