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
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _enemyChasePlayerService.ChasePlayer(_player);

        if(!_enemy.IsPlayerTriggered)
        {
            _enemyStateService.SwitchState(_enemy.EnemyMoveState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
