using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class BossMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    private float specialAttackTimeBtwShots;
    public float specialAttackStartTimeBtwShots;

    public GameObject orbPrefab;

    public Transform player;
    public float magicForce = 20f;

    private bool inRange = false;

    public Light2D bossLights;

    public int[] specialAttacks;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;

        specialAttackTimeBtwShots = specialAttackStartTimeBtwShots;
    }

    void Update()
    {
        float range = Vector2.Distance(transform.position, player.position);

        if (range < 20f)
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
            SpecialAttack();
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

    void SpecialAttack()
    {
        if (specialAttackTimeBtwShots <= 0)
        {
            bossLights.color = Color.red;

            int mySA = specialAttacks[Random.Range(0, specialAttacks.Length)];

            if(mySA == 1)
            {
                Instantiate(orbPrefab, transform.position, Quaternion.identity);

                Instantiate(orbPrefab, transform.position, Quaternion.identity);

                Instantiate(orbPrefab, transform.position, Quaternion.identity);
            }
            else if(mySA == 2)
            {
                Instantiate(orbPrefab, transform.position, Quaternion.identity);

                Instantiate(orbPrefab, transform.position, Quaternion.identity);

                Instantiate(orbPrefab, transform.position, Quaternion.identity);

                Instantiate(orbPrefab, transform.position, Quaternion.identity);
            }
                                 
            specialAttackTimeBtwShots = specialAttackStartTimeBtwShots;
            bossLights.color = Color.white;
        }
        else
        {
            specialAttackTimeBtwShots -= Time.deltaTime;
        }
    }
}
