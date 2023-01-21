using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public PlayerStats PS;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator animator;
    public Transform rightPos, leftPos;
    public int health = 50;
    public int contactDamage = 1;
    public float speed = 10f;

    private int state, nextState;
    private bool idle, isAttacking = false, inPosition = false;
    private float timer;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        BossBehaviour(1);

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

    private void BossBehaviour(int phase)
    {
        if (phase == 1)
        {
            switch (state)
            {
                case 0:

                    break;
                case 1:


                    break;
                case 2:


                    break;
                case 3:

                    break;
            }
        }
    }
    
    

}
