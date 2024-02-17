using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerStateBase
{
    private IPlayerMovementService _playerMovementService;
    private IPlayerAttackService _playerAttackService;

    public PlayerWalkState(Player player, IPlayerStateService playerStateService,IPlayerMovementService playerMovementService,IPlayerAttackService playerAttackService,IPlayerAnimationService playerAnimationService) : base(player, playerStateService, playerAnimationService)
    {
        _playerMovementService = playerMovementService;
        _playerAttackService = playerAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerAnimationService.SetAnimationBool(PlayerAnimation.PlayerAnimationEnum.Run, true);
        Debug.Log("WalkState");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _playerMovementService.HandleMovement();

        if (_playerAttackService.IsAttacking())
        {
            _playerStateService.SwitchState(_player.PlayerStartingAttackState);
        }
        if (!_playerMovementService.IsWalking())
        {
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
        if (_playerSkill.IsUsing)
        {
            _playerStateService.SwitchState(_player.PlayerSkillState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _playerAnimationService.SetAnimationBool(PlayerAnimation.PlayerAnimationEnum.Run, false);

    }
}
