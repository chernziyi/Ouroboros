using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ChaseBehaviour : StateMachineBehaviour
{
    
    private GameObject playerPos;

    public float speed;
    public float hostileRadius;
    public string next;
    Vector3 offset = Vector3.zero;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        offset.x = Random.Range(hostileRadius * -1, hostileRadius);
        offset.x = (float)(offset.x * 0.7); //to cirleize
        offset.y = Random.Range(hostileRadius * -1, hostileRadius);
        offset.y = (float)(offset.y * 0.7);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector2.Distance(animator.transform.position, playerPos.transform.position) > hostileRadius)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.transform.position + offset, speed * Time.deltaTime);
            Vector3 difference = GameObject.FindGameObjectWithTag("Player").transform.position - animator.transform.position; //non homing shite
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            animator.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
        else
        {
            animator.SetBool("Chase",false);

            if (next == "Rush")
            {
                animator.SetBool("Rush", true);
            }
            else if (next == "Shoot")
            {
                animator.SetBool("Shoot", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
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
