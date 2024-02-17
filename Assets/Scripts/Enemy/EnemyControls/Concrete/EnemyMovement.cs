using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : IEnemyMovementService
{
    private Enemy _enemy;


    private bool canCreateRandomPoint;


    public EnemyMovement(Enemy enemy)
    {
        _enemy = enemy;

        _enemy.GetComponent<NavMeshAgent>().speed = _enemy.EnemySO.speed;
    }

    private bool _canMove;
    public bool CanMove
    {
        get
        {
            return _canMove;
        }
        set
        {
            _canMove = value;
            _enemy.GetComponent<NavMeshAgent>().isStopped = !value;
            _enemy.GetComponent<NavMeshAgent>().ResetPath();
        }
    }

    public void HandleMovement()
    {

        if (canCreateRandomPoint)
        {
            if (RandomPoint(_enemy.transform.position, _enemy.EnemySO.maxMoveRange, out Vector3 point))
            {
                MoveToPoint(point, _enemy.EnemySO.speed);
                canCreateRandomPoint = false;
            }
        }
        else if (_enemy.transform.position == _enemy.GetComponent<NavMeshAgent>().destination)
        {
            canCreateRandomPoint = true;
        }
    }

    public void MoveToPoint(Vector3 pointToMove,float speed)
    {
        _enemy.GetComponent<NavMeshAgent>().destination = pointToMove;
        _enemy.GetComponent<NavMeshAgent>().speed = speed;

    }

    public void HandleChase(Player player)
    {
        MoveToPoint(player.transform.position, _enemy.EnemySO.chaseSpeed);

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
