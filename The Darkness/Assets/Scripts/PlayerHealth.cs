using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject playerDeath;
    public Image fade;
    public SpriteRenderer player, left, right;
    public void Update()
    {
        if(health > 100)
        {
            health = 100;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("25"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                health += 25f;
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("50"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                health += 50f;
                Destroy(collision.gameObject);
            }
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
        GameObject effect = Instantiate(playerDeath, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        player.enabled = false;
        right.enabled = false;
        left.enabled = false;
        fade.CrossFadeAlpha(1, 1.5f, true);
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Death Screen");
    }
}
