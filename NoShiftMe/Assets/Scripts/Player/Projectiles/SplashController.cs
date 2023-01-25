using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class SplashController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private int damage;
    public GameObject SplashGameObject;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        rb.MovePosition(transform.position + transform.right * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        BossStats BS = col.GetComponent<BossStats>();

        if (BS != null)
        {
            BS.TakeDamage(damage);
            Destroy(gameObject);
            for (int i = 0; i < Random.Range(0,5); i++)
            {
                var splash = Instantiate(SplashGameObject, transform.position, quaternion.identity);
                splash.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-170, -10));
            }
            
        }
    }
}