using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyStateBase
{
    IEnemyChasePlayerService _enemyChasePlayerService;
    Player _player;

    public EnemyChaseState(Enemy enemy,Player player, IEnemyStateService enemyStateService, IEnemyChasePlayerService enemyChasePlayerService) : base(enemy, enemyStateService)
    {
        _enemyChasePlayerService = enemyChasePlayerService;
        _player = player;
    }

    public override void EnterState()
    {
        base.EnterState();
        _enemy.EnemyAnimation.EnemyAnimationService.SetChasing(true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _enemyChasePlayerService.ChasePlayer(_player);

        if(!_enemy.IsPlayerTriggered)
        {
            _enemyStateService.SwitchState(_enemy.EnemyMoveState);
        }

        if(_enemy.IsPlayerTriggeredToBePreparedForAttack)
        {
            _enemyStateService.SwitchState(_enemy.EnemyPreapareAttackState);
        }
        if (_enemy.IsDead)
        {
            _enemyStateService.SwitchState(_enemy.EnemyDeathState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _enemy.EnemyAnimation.EnemyAnimationService.SetChasing(false);

    }
}
