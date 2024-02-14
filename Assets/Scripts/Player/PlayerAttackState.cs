using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private float attackTimer;

    public PlayerAttackState(Player player, IPlayerStateService playerStateService) : base(player, playerStateService)
    {
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
            Debug.Log("Attacked!");
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
