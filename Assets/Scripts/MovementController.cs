using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Vector3 lastVelocity;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude == 0 && lastVelocity.magnitude > 0)
        {
            animator.Play("Base Layer.Idle");
            agent.destination = transform.position;
        }
        else
        {
            if (Mathf.Abs(input.y) > 0 || Mathf.Abs(input.x) > 0)
            {
                MoveCharacter(input);
            }
        }

        lastVelocity = agent.velocity;
    }

    private void MoveCharacter(Vector2 input)
    {
        
        if (input.x < 0)
        {
            animator.gameObject.transform.localScale = new Vector3(4, 4, 1);
        }
        else
        {
            animator.gameObject.transform.localScale = new Vector3(-4, 4, 1);
        }

        animator.Play("Base Layer.WalkL");

        Vector3 destination = transform.position + Vector3.right * input.x + Vector3.forward * input.y;
        agent.destination = destination;

    }
}
