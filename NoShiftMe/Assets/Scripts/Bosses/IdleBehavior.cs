using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    private int random;
    public float timer;
    public float speed;
    private Transform player;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var distance = Vector2.Distance(animator.transform.position, player.position);

        if (distance > 0)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);
        }
        
        if (timer <= 0)
        {
            random = Random.Range(0, 2);
            if (random == 0)
            {
                animator.SetTrigger("RunRL");
            }
            else if (random == 1)
            {
                animator.SetTrigger("RectRL");
            }
            else
            {
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            timer -= Time.deltaTime;

        }

        
        
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }


}
