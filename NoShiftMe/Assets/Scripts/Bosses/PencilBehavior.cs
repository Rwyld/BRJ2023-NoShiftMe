using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilBehavior : MonoBehaviour
{
    public Transform Player;
    public Transform[] ShootingsPoints;
    public GameObject projetile;
    public float shoot1, shoot2, shoot3;
    
    public Transform LaserPoint;
    public GameObject Laser;
    public float shootLaser;

    public Transform BigShoot;
    public GameObject bigProjecile;
    public float bigAttack;
    
    

    private void Update()
    {
        SecondMove();
    }


    private void FirstMove()
    {
        shoot1 -= Time.deltaTime;
        shoot2 -= Time.deltaTime;
        shoot3 -= Time.deltaTime;

        if (shoot1 < 0)
        {
            var bullet1 = Instantiate(projetile, ShootingsPoints[0].position, ShootingsPoints[0].rotation);
            var bullet2 = Instantiate(projetile, ShootingsPoints[1].position, ShootingsPoints[0].rotation);
            Destroy(bullet1, 3f);
            Destroy(bullet2, 3f);
            shoot1 = 1f;
        }
        if (shoot2 < 0)
        {
            var bullet1 = Instantiate(projetile, ShootingsPoints[2].position, ShootingsPoints[0].rotation);
            var bullet2 = Instantiate(projetile, ShootingsPoints[3].position, ShootingsPoints[0].rotation);
            Destroy(bullet1, 3f);
            Destroy(bullet2, 3f);
            shoot1 = 2f;
        }
        if (shoot3 < 0)
        {
            var bullet1 = Instantiate(projetile, ShootingsPoints[4].position, ShootingsPoints[0].rotation);
            var bullet2 = Instantiate(projetile, ShootingsPoints[6].position, ShootingsPoints[0].rotation);
            Destroy(bullet1, 3f);
            Destroy(bullet2, 3f);
            shoot1 = 1f;
        }

    }

    private void SecondMove()
    {
        shootLaser -= Time.deltaTime;

        if (shootLaser < 0)
        {
            var distance = Vector2.Distance(LaserPoint.position, Player.position);

            var laser = Instantiate(Laser, LaserPoint.position, LaserPoint.rotation);
            Destroy(laser);
            shootLaser = 3f;
            
        }
    }


    private void ThirdMove()
    {
        bigAttack -= Time.deltaTime;

        if (bigAttack  < 0)
        {
            var big = Instantiate(bigProjecile, BigShoot.position, BigShoot.rotation);
            Destroy(big, 3f);
            bigAttack = 3f;
        }
    }
    
    
    
    
    
    
}

  
