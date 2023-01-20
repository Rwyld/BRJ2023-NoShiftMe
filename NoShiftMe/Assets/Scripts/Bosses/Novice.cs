using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Novice : MonoBehaviour
{
    public Transform player;
    public Transform meleeAttackPos;
    public GameObject meleeWeapon;
    [SerializeField] private float speed;

    private void Update()
    {
        BossBehaviour(1);
    }

    private void BossBehaviour(int phase)
    {
        if (phase == 1)
        {
            var probAttack = Random.Range(0, 100);
            if (probAttack <= 40)
            {
                StartCoroutine(MeleeAttack(3f));
            }
            
        }
    }


    private IEnumerator MeleeAttack(float idleTiming)
    {
        var distance = Vector2.Distance(transform.position, player.position);
        if (distance < 2)
        {
            var attack = Instantiate(meleeWeapon, meleeAttackPos.position, Quaternion.identity, this.transform);
            Destroy(attack, 0.2f);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        yield return new WaitForSeconds(idleTiming);
    }
    
}
