using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RushBehaviour : StateMachineBehaviour
{
    
    public float windup;
    public float duration;
    public float delay;
    public float speed;
    public string next;
    private float wTimer;
    private float dTimer;
    Vector2 playerPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        playerPos.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        wTimer = windup + Random.Range(0, delay);
        dTimer = duration;

        Vector3 difference = GameObject.FindGameObjectWithTag("Player").transform.position - animator.transform.position; //non homing shite
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        animator.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 pos;
        pos.x = animator.transform.position.x;
        pos.y = animator.transform.position.y;

        if(wTimer <= 0)
        {
            if(dTimer <= 0 || pos == playerPos)
            {
                animator.SetBool("Rush", false);

                if (next == "Chase")
                {
                    animator.SetBool("Chase", true);
                }
                else if (next == "Shoot")
                {
                    animator.SetBool("Shoot", true);
                }
            }
            else
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos, speed * Time.deltaTime);
                dTimer -= Time.deltaTime;   
            }
        }
        else
        {
            wTimer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
