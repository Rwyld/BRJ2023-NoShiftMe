using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health = 10;
    private float maxHealth = 10;
    private BoxCollider2D col;
    private bool canDamage = true;
    public Image healthbar;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }


    public void TakeDamage(float dmg)
    {
        if(!canDamage) return;
        health -= dmg;
        StartCoroutine(Invulnerability());
    }

    private void Update()
    {
        healthbar.fillAmount = health / maxHealth;

    }

    private IEnumerator Invulnerability()
    {
        canDamage = false;
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
    
    
}
