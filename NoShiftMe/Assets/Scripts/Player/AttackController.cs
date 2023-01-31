using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public PlayerMove PM;
    public GameObject currentWeapon, meleeSpecial;
    public Transform[] weaponPos;

    [SerializeField] private float timeAttack;
    [SerializeField] private float timeAttackCD;
    public bool isAttacking;
    
    public WeaponsBlueprints WeaponBP;
    public string SpecialWeapon;
    public string TypeAttack;

    private float TimeSpecialAttack = 0f;
    private float TimeSpecialAttackCD = 5f;
    private bool specialAttack = false;





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
        SpecialWeapon = WeaponBP.Special;
        TypeAttack = WeaponBP.TypeAttack;
        timeAttackCD = WeaponBP.FireRate;
    }
    

    private void AttackMoves()
    {
        timeAttack -= Time.deltaTime;

        if(specialAttack) return;

        if (Input.GetKey(KeyCode.C) && timeAttack < 0)
        {
            animator.SetBool("IsShooting", true);
            if (TypeAttack == "Multishoot")
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
            animator.SetBool("IsShooting", false);
        }
    }

    
    private void SpecialsAttacks()
    {
        TimeSpecialAttack -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z) & TimeSpecialAttack < 0)
        {
            switch (SpecialWeapon)
            {
                case "AutoAimBurst":
                    for (int i = 0; i < 10; i++)
                    {
                        var AutoAim = Instantiate(currentWeapon, weaponPos[0].position, Quaternion.identity);
                        AutoAim.transform.rotation = Quaternion.Euler(0,0,Random.Range(-15,15));
                        Destroy(AutoAim, 1f);
                    }
                    StartCoroutine(SpecialCountdown());
                    break;
                case "MeleeAttack":
                    var melee = Instantiate(meleeSpecial, weaponPos[0].position, Quaternion.identity, this.transform);
                    Destroy(melee, 0.2f);
                    StartCoroutine(SpecialCountdown());
                    break;
            }
        }
    }


    IEnumerator SpecialCountdown()
    {
        TimeSpecialAttack = TimeSpecialAttackCD;
        specialAttack = true;
        yield return new WaitForSeconds(2f);
        specialAttack = false;
    }

}
