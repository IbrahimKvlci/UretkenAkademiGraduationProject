using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    private float enemyAttackTimer;

    private IEnemyAttackService _enemyAttackService;
    private IEnemyMovementService _enemyMovementService;

    public EnemyAttackState(Enemy enemy, IEnemyStateService enemyStateService,IEnemyAttackService enemyAttackService,IEnemyMovementService enemyMovementService) : base(enemy, enemyStateService)
    {
        _enemyAttackService = enemyAttackService;
        _enemyMovementService = enemyMovementService;
    }


    public override void EnterState()
    {
        base.EnterState();
        enemyAttackTimer = 0;

        _enemyMovementService.CanMove = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemyAttackTimer += Time.deltaTime;
        if (enemyAttackTimer > _enemy.EnemySO.attackSpeed)
        {
            enemyAttackTimer = 0;

            _enemyAttackService.Attack(Player.Instance, _enemy.EnemySO.attackDamage);
        }

        if (!_enemy.IsPlayerTriggeredToBeAttacked)
        {
            _enemyStateService.SwitchState(_enemy.EnemyChaseState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("ExitAttack");

        _enemyMovementService.CanMove = true;
    }

}
