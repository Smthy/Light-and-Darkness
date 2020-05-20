using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject orbPrefab;

    public Transform player;
    public float magicForce = 20f;

    private bool inRange = false;
     

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        float range = Vector2.Distance(transform.position, player.position);

        if (range < 22.5f)
        {
            inRange = true;
            Debug.DrawLine(transform.position, player.transform.position, Color.cyan);
        }
        else
        {
            inRange = false;
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
        }

        if (inRange == true)
        {
            Movement();
            Shooting();
        }
    }

    void Movement()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    void Shooting()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(orbPrefab, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
