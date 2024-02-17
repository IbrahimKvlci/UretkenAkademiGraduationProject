using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    float enemyAttackAnimationTimer;

    private IEnemyAttackService _enemyAttackService;

    public EnemyAttackState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyAttackService enemyAttackService) : base(enemy, enemyStateService)
    {
        _enemyAttackService = enemyAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        enemyAttackAnimationTimer = 0;
        _enemy.EnemyAnimation.EnemyAnimationService.TriggerAttack();
        Debug.Log("Enemy attack state");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        enemyAttackAnimationTimer += Time.deltaTime;
        if (enemyAttackAnimationTimer > _enemy.EnemySO.attackAnimationTime)
        {
            //Timer is over
            enemyAttackAnimationTimer = 0;
            if (_enemy.IsPlayerTriggeredToBeAttacked)
            {
                //Enemy can damage player
                _enemyAttackService.Attack(Player.Instance, _enemy.EnemySO.attackDamage);
            }
            _enemyStateService.SwitchState(_enemy.EnemyPreapareAttackState);
        }

        if (_enemy.IsDead)
        {
            _enemyStateService.SwitchState(_enemy.EnemyDeathState);
        }
    }

    public override void ExitState()
    {
        _enemy.EnemyMovementService.CanMove = true;
        Debug.Log("Enemy attack state exit");

        base.ExitState();
    }
}
