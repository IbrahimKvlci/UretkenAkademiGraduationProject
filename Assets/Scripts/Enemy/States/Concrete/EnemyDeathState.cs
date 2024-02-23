using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyStateBase
{
    private float timer;

    public EnemyDeathState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyMovementService enemyMovement) : base(enemy, enemyStateService)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        _enemy.EnemyAnimation.EnemyAnimationService.TriggerDeath();

        _enemy.EnemySoundController.PlayEnemyDeathSound();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer += Time.deltaTime;
        if(timer>_enemy.EnemySO.deathTime)
        {
            timer = 0;
            _enemy.EnemyHealthService.Destroy(_enemy);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
