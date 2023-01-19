using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    public PlayerMove PM;
    public GameObject currentWeapon;
    public float damage;
    public Transform weaponPos;
    private float timeAttack = 0.5f;
    private float timeAttackCD = 0.5f;
    private bool attack_1 = true;
    private bool attack_2 = false;
    private bool attack_3 = false;
    public bool isAttacking;
    public WeaponsBlueprints WeaponBP;

    private void Update()
    {
        if(PM.isDashing) return;

        AttackMoves();
    }
    
    public void SetWeapon(WeaponsBlueprints Weapon)
    {
        WeaponBP = Weapon;
        currentWeapon = WeaponBP.Weapon;
        damage = WeaponBP.Damage;
    }
    

    private void AttackMoves()
    {
        timeAttack -= Time.deltaTime;

        if (timeAttack < 0)
        {
            attack_1 = true;
            attack_2 = false;
            attack_3 = false;
            isAttacking = false;
        }


        if (Input.GetKeyDown(KeyCode.C) && attack_1)
        {
            var firstAttack = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
            Destroy(firstAttack, 0.2f);
            attack_1 = false;
            attack_2 = true;
            timeAttack = timeAttackCD;
            isAttacking = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && attack_2)
        {
            var secondAttack = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
            Destroy(secondAttack, 0.2f);
            attack_2 = false;
            attack_3 = true;
            timeAttack = timeAttackCD;
        }
        else if (Input.GetKeyDown(KeyCode.C) && attack_3)
        {
            var thirdAttack = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
            Destroy(thirdAttack, 0.2f);
            attack_3 = false;
            attack_1 = true;
            timeAttack = timeAttackCD;
        }
    }
    
    
    
    
}
