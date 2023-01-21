using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 10;
    private BoxCollider2D col;
    private bool canDamage = true;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }


    public void TakeDamage(int dmg)
    {
        if(!canDamage) return;
        health -= dmg;
        StartCoroutine(Invulnerability());
    }

    private IEnumerator Invulnerability()
    {
        canDamage = false;
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
    
    
}
