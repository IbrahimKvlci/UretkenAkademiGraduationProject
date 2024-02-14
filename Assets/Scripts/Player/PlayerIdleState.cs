using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    IPlayerAttackService _playerAttackService;
    IPlayerMovementService _playerMovementService;

    public PlayerIdleState(Player player, IPlayerStateService playerStateService,IPlayerAttackService playerAttackService,IPlayerMovementService playerMovementService) : base(player, playerStateService)
    {
        _playerAttackService = playerAttackService;
        _playerMovementService = playerMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Player Idle State");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_playerAttackService.IsAttacking())
        {
            _playerStateService.SwitchState(_player.PlayerStartingAttackState);
        }
        else if (_playerMovementService.IsWalking())
        {
            _playerStateService.SwitchState(_player.PlayerWalkState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
