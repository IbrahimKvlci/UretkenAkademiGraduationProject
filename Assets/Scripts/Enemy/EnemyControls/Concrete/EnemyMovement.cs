using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement:IEnemyMovementService
{
    private EnemySO _enemySO;

    private NavMeshAgent _navMeshAgent;
    private Transform _enemyTransform;


    private bool canCreateRandomPoint;


    public EnemyMovement(Enemy enemy)
    {
        _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
        _enemyTransform = enemy.transform;
        _enemySO = enemy.EnemySO;

        _navMeshAgent.speed=_enemySO.speed;
    }


    public void HandleMovement()
    {
        if (canCreateRandomPoint)
        {
            if (RandomPoint(_enemyTransform.transform.position, _enemySO.maxMoveRange, out Vector3 point))
            {
                MoveToPoint(point);
                canCreateRandomPoint = false;
            }
        }
        else if (_enemyTransform.transform.position == _navMeshAgent.destination)
        {
            canCreateRandomPoint = true;
        }
    }

    public void MoveToPoint(Vector3 pointToMove)
    {
        _navMeshAgent.destination = pointToMove;
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
