using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 180f);
    }

    void Update()
    {
        Look();
    }
    
    private void Look()
    {
        Quaternion rotation = Quaternion.LookRotation(Player.position - transform.position, transform.TransformDirection(Vector3.up));   
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }
}
