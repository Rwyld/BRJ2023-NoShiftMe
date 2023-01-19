using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    //Materials
    public WeaponsBlueprints Stick;
    public WeaponsBlueprints Rock;
    public WeaponsBlueprints Rope;
    public WeaponsBlueprints Gem;

    //Stick + Rock
    public WeaponsBlueprints Hammer;
    public WeaponsBlueprints Axe;
    
    //Stick + Rope
    public WeaponsBlueprints Whip;
    public WeaponsBlueprints Bow;
    
    //Stick + Gem
    public WeaponsBlueprints Wand;
    public WeaponsBlueprints Staff;
    
    //Rock + Rope
    public WeaponsBlueprints Bowler;
    public WeaponsBlueprints Mangual;
    
    //Rock + Gem
    public WeaponsBlueprints BurstRune;
    public WeaponsBlueprints ElementalRune;
    
    //Gem + Rope
    public WeaponsBlueprints Necklace;
    public WeaponsBlueprints Brazalettes;

    public GameObject Shop;
    public GameObject[] FirstTiers;
    public Button[] FirstTier_Bt;
    
    public GameObject[] SecondTiers;

    
    [SerializeField] private int PowerDamage;
    public AttackController AC;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shop.SetActive(true);
            GenerateShop(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Shop.SetActive(true);
            GenerateShop(2);
        }
    }
    
    private void GenerateShop(int Tier)
    {
        if (Tier == 1)
        {
            foreach (var buttoms in FirstTiers)
            {
                buttoms.SetActive(true);
            }
        }

        if (Tier == 2)
        {
            foreach (var buttoms in FirstTiers)
            {
                buttoms.SetActive(false);
            }
            
            switch (PowerDamage)
            {
                case 3:
                    SecondTiers[0].SetActive(true);
                    SecondTiers[1].SetActive(true);
                    break;
                case 4:
                    SecondTiers[2].SetActive(true);
                    SecondTiers[3].SetActive(true);
                    break;
                case 5:
                    SecondTiers[4].SetActive(true);
                    SecondTiers[5].SetActive(true);
                    break;
                case 6:
                    SecondTiers[6].SetActive(true);
                    SecondTiers[7].SetActive(true);
                    break;
                case 7:
                    SecondTiers[8].SetActive(true);
                    SecondTiers[9].SetActive(true);
                    break;
                case 8:
                    SecondTiers[10].SetActive(true);
                    SecondTiers[11].SetActive(true);
                    break;
            }
        }
    }
    
    
    public void StickShop()
    {
        AC.SetWeapon(Stick);
        FirstTier_Bt[0].interactable = false;

        PowerDamage += 1;
        Shop.SetActive(false);
        
    }
    public void RockShop()
    {
        AC.SetWeapon(Rock);
        FirstTier_Bt[1].interactable = false;

        PowerDamage += 2;
        Shop.SetActive(false);

    }
    public void RopeShop()
    {
        AC.SetWeapon(Rope);
        FirstTier_Bt[2].interactable = false;

        if (PowerDamage is 2 or 4) {PowerDamage += 4;}
        else PowerDamage += 3;
        Shop.SetActive(false);

    }
    public void GemShop()
    {
        AC.SetWeapon(Gem);
        FirstTier_Bt[3].interactable = false;

        if (PowerDamage is 2 or 3) {PowerDamage += 5;}
        else PowerDamage += 4;
        Shop.SetActive(false);

    }
    public void HammerShop()
    {
        AC.SetWeapon(Hammer);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void AxeShop()
    {
        AC.SetWeapon(Axe);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void WhipShop()
    {
        AC.SetWeapon(Whip);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void BowShop()
    {
        AC.SetWeapon(Bow);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void WandShop()
    {
        AC.SetWeapon(Wand);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void StaffShop()
    {
        AC.SetWeapon(Staff);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void BowlerShop()
    {
        AC.SetWeapon(Bowler);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void MangualShop()
    {
        AC.SetWeapon(Mangual);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void BurstRuneShop()
    {
        AC.SetWeapon(BurstRune);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void ElementalRuneShop()
    {
        AC.SetWeapon(ElementalRune);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void NecklaceShop()
    {
        AC.SetWeapon(Necklace);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    public void BrazalettesShop()
    {
        AC.SetWeapon(Brazalettes);
        PowerDamage += 10;
        Shop.SetActive(false);
    }
    
}
