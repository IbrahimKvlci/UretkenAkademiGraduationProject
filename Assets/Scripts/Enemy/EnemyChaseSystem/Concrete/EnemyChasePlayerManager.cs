using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasePlayerManager : IEnemyChasePlayerService
{
    IEnemyMovementService _enemyMovementService;

    public EnemyChasePlayerManager(IEnemyMovementService enemyMovementService)
    {
        _enemyMovementService = enemyMovementService;
    }

    public void ChasePlayer(Player player)
    {
        _enemyMovementService.MoveToPoint(player.transform.position);
    }
}
