using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    bool isMoving = false;
    Transform target;
    
    Animator animator;
    NavMeshAgent nv;

    void Start() 
    {
        animator = GetComponent<Animator>();
        nv = this.GetComponent<NavMeshAgent>();
	}

    public void MoveToDestination(Vector3 point)
        {
            nv.SetDestination(point);
		}

    public void GoToTarget(Vector3 point)
        {
            nv.SetDestination(point);
            

		}

    void Update()
    {
        if (nv.remainingDistance > nv.stoppingDistance)
            {
                isMoving = true;     
			}
        if (nv.remainingDistance <= nv.stoppingDistance)
            {
                isMoving = false;     
			}
        animator.SetBool("isWalking", isMoving);
	}

   void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.tag == "Enemy")
       {
            Debug.Log("Begin Attacking");
            animator.SetTrigger("attack");
            
		}
	}
       
}

