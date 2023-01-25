using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProyectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * (speed * Time.deltaTime);
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
