using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredBehaviour : StateMachineBehaviour
{
    private Transform playerPos;

    public float scaredDelay;
    private float sTimer;
    public float braveRadius;
    public float speed;
    public string next;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        sTimer = scaredDelay;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(sTimer <= 0)
        {
            if (Vector2.Distance(animator.transform.position, playerPos.position) < braveRadius)
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, -speed * Time.deltaTime);
                Vector3 difference = GameObject.FindGameObjectWithTag("Player").transform.position - animator.transform.position; //non homing shite
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                animator.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 90);
            }
            else
            {
                animator.SetBool("Scared", false);

                if (next == "Rush")
                {
                    animator.SetBool("Rush", true);
                }
                else if (next == "Shoot")
                {
                    animator.SetBool("Shoot", true);
                }
                else if (next == "Chase")
                {
                    animator.SetBool("Chase", true);
                }
            }
        }
        else
        {
            sTimer -= Time.deltaTime;
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
