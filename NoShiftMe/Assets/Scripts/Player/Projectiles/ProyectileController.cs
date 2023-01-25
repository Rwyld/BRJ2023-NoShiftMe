using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private int damage;
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
        }
    }
}
