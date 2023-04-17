using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private Vector3 startLocation;
    [SerializeField] private Vector3 targetLocation;
    private bool movingToTarget = true;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
        startLocation = transform.position;
        targetLocation = new Vector3(-8.494f, 0.15f, -8.21f);
    }


    // Update is called once per frame
    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            if (movingToTarget)
            {
                SetDestination(startLocation);
            }
            else
            {
                SetDestination(targetLocation);
            }

            movingToTarget = !movingToTarget;
        }
    }

    void SetDestination(Vector3 destination)
    {
        NavMeshHit hit;
         NavMesh.SamplePosition(destination, out hit, 10f, NavMesh.AllAreas);
         navMeshAgent.SetDestination(hit.position);
    }


}
