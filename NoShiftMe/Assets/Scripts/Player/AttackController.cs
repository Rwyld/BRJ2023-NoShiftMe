using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AttackController : MonoBehaviour
{
    public PlayerMove PM;
    public GameObject currentWeapon, meleeSpecial;
    public string nameWeapon;
    public float damage;
    public Transform[] weaponPos;

    [SerializeField] private float timeAttack = 0.5f;
    [SerializeField] private float timeAttackCD = 0.5f;
    private bool attack_1 = true;
    private bool attack_2 = false;
    private bool attack_3 = false;
    public bool isAttacking;
    
    public WeaponsBlueprints WeaponBP;
    
    public WeaponsManager WP;
    private float TimeSpecialAttack = 1f;
    private float TimeSpecialAttackCD = 1f;
    private bool specialAttack = true;
    [SerializeField] private bool multishoot = false;
        
    
    
    

    private void Update()
    {
        if(PM.isDashing) return;

        AttackMoves();
        SpecialsAttacks();
    }
    
    public void SetWeapon(WeaponsBlueprints Weapon)
    {
        WeaponBP = Weapon;
        currentWeapon = WeaponBP.Weapon;
        damage = WeaponBP.Damage;
        nameWeapon = WeaponBP.Name;
        timeAttackCD = WeaponBP.FireRate;
    }
    

    private void AttackMoves()
    {
        timeAttack -= Time.deltaTime;

        if(specialAttack) return;

        if (Input.GetKey(KeyCode.C) && timeAttack <= 0)
        {
            if (multishoot == true)
            {
                foreach (var pos in weaponPos)
                {
                    var bullets = Instantiate(currentWeapon);
                    bullets.transform.position = pos.position;
                    bullets.transform.rotation = transform.rotation;
                    Destroy(bullets, 1f);
                }
            }
            else
            {
                var bullets = Instantiate(currentWeapon);
                bullets.transform.position = weaponPos[0].position;
                bullets.transform.rotation = transform.rotation;
                Destroy(bullets, 1f);
            }
            
            

            timeAttack = timeAttackCD;
            isAttacking = true;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            isAttacking = false;
        }
    }

    
    private void SpecialsAttacks()
    {
        TimeSpecialAttack -= Time.deltaTime;

        if (TimeSpecialAttack < 0)
        {
            specialAttack = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) & specialAttack == false)
        {
            switch (nameWeapon)
            {
                case "AutoAimBurst":
                    for (int i = 0; i < 10; i++)
                    {
                        var AutoAim = Instantiate(currentWeapon, weaponPos[0].position, Quaternion.identity, this.transform);
                        AutoAim.transform.rotation = Quaternion.Euler(0,0,Random.Range(-15,15));
                    }
                    specialAttack = true;
                    break;
                case "MeleeAttack":
                    var melee = Instantiate(meleeSpecial, weaponPos[0].position, Quaternion.identity, this.transform);
                    Destroy(melee, 0.2f);
                    break;
            }
            
            
        }
        
        
        
    }


}
