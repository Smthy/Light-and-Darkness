using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject boss;
    public Vector3 axis;
    public float angle;

    public GameObject player;
    public GameObject destroyEffect;

    void Update()
    {
        transform.RotateAround(boss.transform.position, axis, angle);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
    }
}
