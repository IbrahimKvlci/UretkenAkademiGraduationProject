using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private Vector3 pointToMove;
    private float range = 10.0f;
    private bool canCreateRandomPoint;
    private float moveToAttackRange = 10f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        canCreateRandomPoint = true;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (canCreateRandomPoint)
        {
            if (RandomPoint(transform.position, range, out Vector3 point))
            {
                pointToMove = point;
                canCreateRandomPoint = false;
            }
        }
        else if (transform.position == navMeshAgent.destination)
        {
            canCreateRandomPoint = true;
        }

        navMeshAgent.destination = pointToMove;
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
