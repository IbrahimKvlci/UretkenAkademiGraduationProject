using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    IEnemyMovementService enemyMovement;

    public EnemyMoveState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyMovementService enemyMovement) : base(enemy, enemyStateService)
    {
        this.enemyMovement = enemyMovement;
    }

    public override void EnterState()
    {
        base.EnterState();
        enemyMovement.CanMove = true;

    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemyMovement.HandleMovement();

        if(_enemy.IsPlayerTriggered)
        {
            _enemyStateService.SwitchState(_enemy.EnemyChaseState);
        }
        if (_enemy.IsDead)
        {
            _enemyStateService.SwitchState(_enemy.EnemyDeathState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
