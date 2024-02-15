using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private float attackTimer;

    private IPlayerAttackService _playerAttackService;

    public PlayerAttackState(Player player, IPlayerStateService playerStateService,IPlayerAttackService playerAttackService) : base(player, playerStateService)
    {
        _playerAttackService=playerAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        attackTimer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        attackTimer += Time.deltaTime;
        if(attackTimer>_player.WeaponSO.speed)
        {
            attackTimer = 0;
            if(_player.EnemyTriggeredToBeAttacked!=null)
            {
                _playerAttackService.Attack(_player.EnemyTriggeredToBeAttacked, _player.WeaponSO);
            }
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
