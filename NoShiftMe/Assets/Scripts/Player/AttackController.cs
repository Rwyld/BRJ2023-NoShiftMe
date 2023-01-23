using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackController : MonoBehaviour
{
    public PlayerMove PM;
    public GameObject currentWeapon;
    public string nameWeapon;
    public float damage;
    public Transform weaponPos;

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
    }
    

    private void AttackMoves()
    {
        timeAttack -= Time.deltaTime;

        if(specialAttack) return;

        if (Input.GetKey(KeyCode.C) && timeAttack <= 0)
        {
            var bullets = Instantiate(currentWeapon);
            bullets.transform.position = weaponPos.position;
            bullets.transform.rotation = transform.rotation;
            Destroy(bullets, 1f);
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
                case "Hammer":
                    var Hammer = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Hammer, 0.2f);
                    StartCoroutine(MoreDamage(10));
                    Hammer.transform.localScale = new Vector3(2f, 2f,1f);
                    Hammer.transform.localPosition += new Vector3(1, 0, 0);
                    specialAttack = true;
                    break;
                case "Axe":
                    var Axe = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Axe, 0.2f);
                    StartCoroutine(MoreDamage(15));
                    Axe.transform.localScale = new Vector3(2f, 2f,1f);
                    Axe.transform.localPosition += new Vector3(1, 0, 0);
                    break;
                case "Whip":
                    var Whip = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Whip, 0.2f);
                    StartCoroutine(MoreDamage(15));
                    Whip.transform.localScale = new Vector3(3f, 1f, 1f);
                    break;
                case "Bow":
                    var Bow1 = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    var Bow2 = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    var Bow3 = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Bow1, 0.2f);
                    Destroy(Bow2, 0.2f);
                    Destroy(Bow3, 0.2f);
                    StartCoroutine(MoreDamage(0));
                    Bow1.transform.localRotation = Quaternion.Euler(0, 0f, -30f);
                    Bow2.transform.localRotation = Quaternion.Euler(0, 0f, -20f);
                    Bow3.transform.localRotation = Quaternion.Euler(0, 0f, -10f);
                    break;
                case "Wand":
                    var Wand = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Wand, 0.2f);
                    StartCoroutine(MoreDamage(10));
                    Wand.transform.localScale = new Vector3(2f, 2f, 1f);
                    break;
                case "Staff":
                    var Staff = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Staff, 0.2f);
                    StartCoroutine(MoreDamage(-10));
                    Staff.transform.localScale = new Vector3(4f, 1f, 1f);
                    Staff.transform.localRotation = Quaternion.Euler(0,0f,-90f);
                    Staff.transform.localRotation = Quaternion.Euler(0,0f ,0f * Time.deltaTime * 10f);
                    break;
                case "Bowler":
                    var Bowler = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Bowler, 0.2f);
                    StartCoroutine(MoreDamage(5));
                    Bowler.transform.localScale = new Vector3(2f, 2f, 1f);
                    break;
                case "Mangual":
                    var Mangual = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Mangual, 0.2f);
                    StartCoroutine(MoreDamage(15));
                    Mangual.transform.localScale = new Vector3(2f, 2f, 1f);
                    break;
                case "BurstRune":
                    var BurstRune = Instantiate(currentWeapon, transform.position, Quaternion.identity, this.transform);
                    Destroy(BurstRune, 0.2f);
                    StartCoroutine(MoreDamage(30));
                    BurstRune.transform.localScale = new Vector3(3f, 3f, 1f);
                    break;
                case "ElementalRune":
                    var ElementalRune = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(ElementalRune, 0.2f);
                    StartCoroutine(MoreDamage(20));
                    ElementalRune.transform.localScale = new Vector3(3f, 1f, 1f);
                    break;
                case "Necklace":
                    var Necklace = Instantiate(currentWeapon, transform.position, Quaternion.identity, this.transform);
                    Destroy(Necklace, 0.2f);
                    StartCoroutine(MoreDamage(30));
                    Necklace.transform.localScale = new Vector3(3f, 1f, 1f);
                    break;
                case "Brazalettes":
                    var Brazalettes1 = Instantiate(currentWeapon, weaponPos.position, Quaternion.identity, this.transform);
                    var Brazalettes2 = Instantiate(currentWeapon, -weaponPos.position, Quaternion.identity, this.transform);
                    Destroy(Brazalettes1, 0.2f);
                    Destroy(Brazalettes2, 0.2f);
                    StartCoroutine(MoreDamage(20));
                    Brazalettes1.transform.localScale = new Vector3(3f, 1f, 1f);
                    Brazalettes2.transform.localScale = new Vector3(3f, 1f, 1f);
                    break;
            }
            
            
        }
        
        
        
    }

    private IEnumerator MoreDamage(int specialDamage)
    {
        TimeSpecialAttack = TimeSpecialAttackCD;
        damage += specialDamage;
        yield return new WaitForSeconds(0.2f);
        damage -= specialDamage;
        specialAttack = false;
    }
    
    
}
