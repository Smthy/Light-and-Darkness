using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource bossMusic, backgroundMusic;

    public void Start()
    {
        backgroundMusic.Play();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bossMusic.Play();
            backgroundMusic.Pause();
        }        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            backgroundMusic.Play();
            bossMusic.Pause();
        }
    }
}
