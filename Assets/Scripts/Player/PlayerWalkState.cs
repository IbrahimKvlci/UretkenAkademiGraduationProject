using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private IPlayerMovementService _playerMovementService;
    private IPlayerAttackService _playerAttackService;

    public PlayerWalkState(Player player, IPlayerStateService playerStateService,IPlayerMovementService playerMovementService,IPlayerAttackService playerAttackService) : base(player, playerStateService)
    {
        _playerMovementService = playerMovementService;
        _playerAttackService = playerAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _playerMovementService.HandleMovement();

        if (_playerAttackService.IsAttacking())
        {
            _playerStateService.SwitchState(_player.PlayerStartingAttackState);
        }
        else if (!_playerMovementService.IsWalking())
        {
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
