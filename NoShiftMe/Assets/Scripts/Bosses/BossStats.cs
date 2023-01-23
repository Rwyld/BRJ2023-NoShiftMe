using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossStats : MonoBehaviour
{
    public PlayerStats PS;
    public int health;
    private BoxCollider2D col;
    private float contactDamage = 1;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }


    public void TakeDamage(int dmg)
    {
        health -= dmg;

        if (health == 0)
        {
            col.enabled = false;
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            PS.TakeDamage(contactDamage);
        }
    }
}
