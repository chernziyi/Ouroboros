using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ShootBehaviour : StateMachineBehaviour
{
    public GameObject projectile;
    public float windup;
    private float wTimer;
    public float delay;
    Vector2 playerPos;

    public string next;
    public bool scaredy;
    public float scaredRadius;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        playerPos.y = GameObject.FindGameObjectWithTag("Player").transform.position.y;

        wTimer = windup + Random.Range(0, delay);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wTimer <= 0)
        {
            Instantiate(projectile, animator.transform.position, Quaternion.identity);

            animator.SetBool("Shoot", false);

            if (next == "Chase")
            {
                animator.SetBool("Chase", true);
            }
            else if (next == "Rush")
            {
                animator.SetBool("Rush", true);
            }
        }
        else
        {
            if (scaredy == true)
            {
                if (Vector2.Distance(animator.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < scaredRadius)
                {
                    animator.SetBool("Shoot", false);
                    animator.SetBool("Scared", true);
                }
            }

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
