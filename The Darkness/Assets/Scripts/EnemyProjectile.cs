using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public float damage = 20f;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        StartCoroutine(DestroyProjectile());
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = collision.transform.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
        }
        if(collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
