using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsManager : MonoBehaviour
{
    //Pencil
    public WeaponsBlueprints Tainted_Balls;
    public WeaponsBlueprints Basic_Fireup;

    //Pincel
    public WeaponsBlueprints Splash_Tainted_Balls;
    public WeaponsBlueprints Multi_Tainted_Balls;
    public WeaponsBlueprints Splash_Basic_Fireup;
    public WeaponsBlueprints Multi_Basic_Fireup;

    //Ruler
    public WeaponsBlueprints AA_Splash_Tainted_Balls;
    public WeaponsBlueprints MA_Splash_Tainted_Balss;
    public WeaponsBlueprints AA_Multi_Tainted_Balls;
    public WeaponsBlueprints MA_Multi_Tainted_Balss;

    public WeaponsBlueprints AA_Splash_Basic_Fireup;
    public WeaponsBlueprints MA_Splash_Basic_Fireup;
    public WeaponsBlueprints AA_Multi_Basic_Fireup;
    public WeaponsBlueprints MA_Multi_Basic_Fireup;

    //Marker
    public WeaponsBlueprints Rainbow_AA_Splash_Tainted_Balls;
    public WeaponsBlueprints Rainbow_MA_Splash_Tainted_Balss;
    public WeaponsBlueprints Rainbow_AA_Multi_Tainted_Balls;
    public WeaponsBlueprints Rainbow_MA_Multi_Tainted_Balss;

    public WeaponsBlueprints Rainbow_AA_Splash_Basic_Fireup;
    public WeaponsBlueprints Rainbow_MA_Splash_Basic_Fireup;
    public WeaponsBlueprints Rainbow_AA_Multi_Basic_Fireup;
    public WeaponsBlueprints Rainbow_MA_Multi_Basic_Fireup;

    public WeaponsBlueprints FireUpPlus_AA_Splash_Tainted_Balls;
    public WeaponsBlueprints FireUpPlus_MA_Splash_Tainted_Balss;
    public WeaponsBlueprints FireUpPlus_AA_Multi_Tainted_Balls;
    public WeaponsBlueprints FireUpPlus_MA_Multi_Tainted_Balss;

    public WeaponsBlueprints FireUpPlus_AA_Splash_Basic_Fireup;
    public WeaponsBlueprints FireUpPlus_MA_Splash_Basic_Fireup;
    public WeaponsBlueprints FireUpPlus_AA_Multi_Basic_Fireup;
    public WeaponsBlueprints FireUpPlus_MA_Multi_Basic_Fireup;

    public GameObject Shop;
    public GameObject[] PencilBoss, PincelBoss, RulerBoss, MarkerBoss;


    public int WeaponType;
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
            foreach (var buttoms in PencilBoss)
            {
                buttoms.SetActive(true);
            }
        }

        if (Tier == 2)
        {
            foreach (var buttoms in PincelBoss)
            {
                buttoms.SetActive(false);
            }

            switch (WeaponType)
            {
                case 1:
                    PincelBoss[0].SetActive(true);
                    PincelBoss[1].SetActive(true);
                    break;
                case 2:
                    PincelBoss[2].SetActive(true);
                    PincelBoss[3].SetActive(true);
                    break;
            }
        }
        if (Tier == 3)
        {
            foreach (var buttoms in RulerBoss)
            {
                buttoms.SetActive(false);
            }

            switch (WeaponType)
            {
                case 3:
                    RulerBoss[0].SetActive(true);
                    RulerBoss[1].SetActive(true);
                    break;
                case 4:
                    RulerBoss[2].SetActive(true);
                    RulerBoss[3].SetActive(true);
                    break;
                case 5:
                    RulerBoss[4].SetActive(true);
                    RulerBoss[5].SetActive(true);
                    break;
                case 6:
                    RulerBoss[6].SetActive(true);
                    RulerBoss[7].SetActive(true);
                    break;
            }
        }
        
        if (Tier == 4)
        {
            foreach (var buttoms in MarkerBoss)
            {
                buttoms.SetActive(false);
            }

            switch (WeaponType)
            {
                case 7:
                    MarkerBoss[0].SetActive(true);
                    MarkerBoss[1].SetActive(true);
                    break;
                case 8:
                    MarkerBoss[2].SetActive(true);
                    MarkerBoss[3].SetActive(true);
                    break;
                case 9:
                    MarkerBoss[4].SetActive(true);
                    MarkerBoss[5].SetActive(true);
                    break;
                case 10:
                    MarkerBoss[6].SetActive(true);
                    MarkerBoss[7].SetActive(true);
                    break;
                case 11:
                    MarkerBoss[8].SetActive(true);
                    MarkerBoss[9].SetActive(true);
                    break;
                case 12:
                    MarkerBoss[10].SetActive(true);
                    MarkerBoss[11].SetActive(true);
                    break;
                case 13:
                    MarkerBoss[12].SetActive(true);
                    MarkerBoss[13].SetActive(true);
                    break;
                case 14:
                    MarkerBoss[14].SetActive(true);
                    MarkerBoss[15].SetActive(true);
                    break;
            }
        }
    }


    public void TaintedShop()
    {
        AC.SetWeapon(Tainted_Balls);
        WeaponType = 1;
        Shop.SetActive(false);
    }

    public void BasicFireupShop()
    {
        AC.SetWeapon(Basic_Fireup);
        WeaponType = 2;
        Shop.SetActive(false);
    }

    public void SplashTaintedShop()
    {
        AC.SetWeapon(Splash_Tainted_Balls);
        WeaponType = 3;
        Shop.SetActive(false);
    }

    public void MultiTaintedShop()
    {
        AC.SetWeapon(Multi_Tainted_Balls);
        WeaponType = 4;
        Shop.SetActive(false);
    }

    public void SplashBasicShop()
    {
        AC.SetWeapon(Splash_Basic_Fireup);
        WeaponType = 5;
        Shop.SetActive(false);
    }

    public void MultiBasicShop()
    {
        AC.SetWeapon(Multi_Basic_Fireup);
        WeaponType = 6;
        Shop.SetActive(false);
    }
    public void AA_SplashTaintedShop()
    {
        AC.SetWeapon(AA_Splash_Tainted_Balls);
        WeaponType = 7;
        Shop.SetActive(false);
    }
    public void MA_SplashTaintedShop()
    {
        AC.SetWeapon(MA_Splash_Tainted_Balss);
        WeaponType = 8;
        Shop.SetActive(false);
    }
    public void AA_MultiTaintedShop()
    {
        AC.SetWeapon(AA_Multi_Tainted_Balls);
        WeaponType = 9;
        Shop.SetActive(false);
    }
    public void MA_MultiTaintedShop()
    {
        AC.SetWeapon(MA_Multi_Tainted_Balss);
        WeaponType = 10;
        Shop.SetActive(false);
    }
    public void AA_SplashBasicShop()
    {
        AC.SetWeapon(AA_Splash_Basic_Fireup);
        WeaponType = 11;
        Shop.SetActive(false);
    }
    public void MA_SplashBasicShop()
    {
        AC.SetWeapon(MA_Splash_Basic_Fireup);
        WeaponType = 12;
        Shop.SetActive(false);
    }
    public void AA_MultiBasicShop()
    {
        AC.SetWeapon(AA_Multi_Basic_Fireup);
        WeaponType = 13;
        Shop.SetActive(false);
    }
    public void MA_MultiBasicShop()
    {
        AC.SetWeapon(MA_Multi_Basic_Fireup);
        WeaponType = 14;
        Shop.SetActive(false);
    }
    
    //Marker
    public void Rainbow_AA_SplashTaintedShop()
    {
        AC.SetWeapon(Rainbow_AA_Splash_Tainted_Balls);
        WeaponType = 15;
        Shop.SetActive(false);
    }
    public void Rainbow_MA_SplashTaintedShop()
    {
        AC.SetWeapon(Rainbow_MA_Splash_Tainted_Balss);
        WeaponType = 16;
        Shop.SetActive(false);
    }
    public void Rainbow_AA_MultiTaintedShop()
    {
        AC.SetWeapon(Rainbow_AA_Multi_Tainted_Balls);
        WeaponType = 17;
        Shop.SetActive(false);
    }
    public void Rainbow_MA_MultiTaintedShop()
    {
        AC.SetWeapon(Rainbow_MA_Multi_Tainted_Balss);
        WeaponType = 18;
        Shop.SetActive(false);
    }
    public void FireUpPlus_AA_SplashTaintedShop()
    {
        AC.SetWeapon(FireUpPlus_AA_Splash_Tainted_Balls);
        WeaponType = 19;
        Shop.SetActive(false);
    }
    public void FireUpPlus_MA_SplashTaintedShop()
    {
        AC.SetWeapon(FireUpPlus_MA_Splash_Tainted_Balss);
        WeaponType = 20;
        Shop.SetActive(false);
    }
    public void FireUpPlus_AA_MultiTaintedShop()
    {
        AC.SetWeapon(FireUpPlus_AA_Multi_Tainted_Balls);
        WeaponType = 21;
        Shop.SetActive(false);
    }
    public void FireUpPlus_MA_MultiTaintedShop()
    {
        AC.SetWeapon(FireUpPlus_MA_Multi_Tainted_Balss);
        WeaponType = 22;
        Shop.SetActive(false);
    }
    
    public void Rainbow_AA_SplashBasicShop()
    {
        AC.SetWeapon(Rainbow_AA_Splash_Basic_Fireup);
        WeaponType = 23;
        Shop.SetActive(false);
    }
    public void Rainbow_MA_SplashBasicShop()
    {
        AC.SetWeapon(Rainbow_MA_Splash_Basic_Fireup);
        WeaponType = 24;
        Shop.SetActive(false);
    }
    public void Rainbow_AA_MultiBasicShop()
    {
        AC.SetWeapon(Rainbow_AA_Multi_Basic_Fireup);
        WeaponType = 25;
        Shop.SetActive(false);
    }
    public void Rainbow_MA_MultiBasicShop()
    {
        AC.SetWeapon(Rainbow_MA_Multi_Basic_Fireup);
        WeaponType = 26;
        Shop.SetActive(false);
    }
    
    public void FireUpPlus_AA_SplashBasicShop()
    {
        AC.SetWeapon(FireUpPlus_AA_Splash_Basic_Fireup);
        WeaponType = 27;
        Shop.SetActive(false);
    }
    public void FireUpPlus_MA_SplashBasicShop()
    {
        AC.SetWeapon(FireUpPlus_MA_Splash_Basic_Fireup);
        WeaponType = 28;
        Shop.SetActive(false);
    }
    public void FireUpPlus_AA_MultiBasicShop()
    {
        AC.SetWeapon(FireUpPlus_AA_Multi_Basic_Fireup);
        WeaponType = 29;
        Shop.SetActive(false);
    }
    public void FireUpPlus_MA_MultiBasicShop()
    {
        AC.SetWeapon(FireUpPlus_MA_Multi_Basic_Fireup);
        WeaponType = 30;
        Shop.SetActive(false);
    }
    
}
