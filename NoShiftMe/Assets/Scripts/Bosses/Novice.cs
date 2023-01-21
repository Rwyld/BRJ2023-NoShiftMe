using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;
using Random = UnityEngine.Random;

public class Novice : MonoBehaviour
{
    public PlayerStats PS;
    public Transform player;
    public Transform meleeAttackPos, rangeAttackPos, runAttack;
    public Transform rightJumpPos, leftJumpPos;
    private BoxCollider2D col;
    public GameObject meleeWeapon, proyectile;
   
    [SerializeField] private float speed;
    private float jumpForce = 10f;
    private float timer = 3f;
    
    //States
    [SerializeField] private int state, currentState, nextState;
    private bool idle = true, meleeAttack, rangeAttack;
    private bool isAttacking = false;

    //Run Attack
    private bool inPosition = false;
    private bool rightToLeft = false, leftToRight = false;
    private float runAttackCD = 0.5f;
    
    //Stats
    public int health;
    public int contactDamage;
    
    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
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
            if (idle)
            {
                nextState = Random.Range(0, 3);
                if (nextState == state)
                {
                    nextState = Random.Range(0,3);
                }
            }

            switch (state)
            {
                case 0:
                    idle = false;
                    Timer(2f);
                    break;
                case 1:
                    idle = false;
                    Timer(6f);
                    MeleeAttack();
                    break;
                case 2:
                    idle = false;
                    Timer(1f);
                    RangeAttack();
                    break;
                case 3:
                    idle = false;
                    Timer(2f);
                    break;
            }
        }
    }

    private void Timer(float idleTiming)
    {
        timer -= Time.deltaTime;

        if (!(timer < 0)) return;
        isAttacking = false;
        idle = true;
        timer = idleTiming;
        state = nextState;
        
    }


    private void MeleeAttack()
    {
        if (isAttacking) return;
        
        var distance = Vector2.Distance(transform.position, player.position);
        if (distance < 2)
        {
            isAttacking = true;
            var attack = Instantiate(meleeWeapon, meleeAttackPos.position, Quaternion.identity, this.transform);
            transform.position -= Vector3.left * (speed * jumpForce * Time.deltaTime);
            Destroy(attack, 0.2f);
        }
        else
        {
            LookDirection();
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void RangeAttack()
    {
        LookDirection();
        if(isAttacking) return;
        
        var proyectile1 = Instantiate(proyectile, rangeAttackPos.position, Quaternion.identity);
        var proyectile2 = Instantiate(proyectile, rangeAttackPos.position, Quaternion.identity);
        var proyectile3 = Instantiate(proyectile, rangeAttackPos.position, Quaternion.identity);
        var proyectile4 = Instantiate(proyectile, rangeAttackPos.position, Quaternion.identity);
        
        proyectile1.transform.localRotation = Quaternion.Euler(0,0,60f);
        proyectile2.transform.localRotation = Quaternion.Euler(0,0,50f);
        proyectile3.transform.localRotation = Quaternion.Euler(0,0,40f);
        proyectile4.transform.localRotation = Quaternion.Euler(0,0,30f);
        
        Destroy(proyectile1, 1f);
        Destroy(proyectile2, 1f);
        Destroy(proyectile3, 1f);
        Destroy(proyectile4, 1f);

        isAttacking = true;
    }

    private void RunAttack()
    {
        var distanceR = Vector2.Distance(transform.position, rightJumpPos.position);
        var distanceL = Vector2.Distance(transform.position, leftJumpPos.position);
        
        if (distanceL > distanceR && inPosition == false)
        {
            LookDirection();
            transform.position = Vector2.MoveTowards(transform.position, rightJumpPos.position, speed * 2 * Time.deltaTime);
            if (distanceR == 0)
            {
                inPosition = true;
                rightToLeft = true;
            }
        }
        else if (distanceL < distanceR && inPosition == false)
        {
            LookDirection();
            transform.position = Vector2.MoveTowards(transform.position, leftJumpPos.position, speed * 2 * Time.deltaTime);
            if (distanceL == 0)
            {
                inPosition = true;
                leftToRight = true;
            }
        }

        else if (rightToLeft == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftJumpPos.position, speed * Time.deltaTime);

            runAttackCD -= Time.deltaTime;

            if (runAttackCD < 0 && distanceL > 1)
            {
                var proyectileUP = Instantiate(proyectile, runAttack.position, Quaternion.identity);
                Destroy(proyectileUP, 1.5f);

                var meleeRun = Instantiate(meleeWeapon, meleeAttackPos.position, Quaternion.identity);
                Destroy(meleeRun, 0.5f);
                runAttackCD = 0.5f;
            }
            else
            {
                rightToLeft = false;
                LookDirection();
            }
        }
        
        else if (leftToRight == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightJumpPos.position, speed * Time.deltaTime);

            runAttackCD -= Time.deltaTime;

            if (runAttackCD < 0 && distanceL > 1)
            {
                var proyectileUP = Instantiate(proyectile, runAttack.position, Quaternion.identity);
                Destroy(proyectileUP, 1.5f);

                var meleeRun = Instantiate(meleeWeapon, meleeAttackPos.position, Quaternion.identity);
                Destroy(meleeRun, 0.5f);
                runAttackCD = 0.5f;
            }
            else
            {
                leftToRight = false;
                LookDirection();
            }
        }
        
    }

    private void LookDirection()
    {
        if (transform.position.x > player.position.x)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
    
}
