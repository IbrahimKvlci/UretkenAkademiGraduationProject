using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    IPlayerAttackService _playerAttackService;
    IPlayerMovementService _playerMovementService;

    public PlayerIdleState(Player player, IPlayerStateService playerStateService,IPlayerAttackService playerAttackService,IPlayerMovementService playerMovementService,IPlayerAnimationService playerAnimationService,IPlayerHealthService playerHealthService) : base(player, playerStateService,playerAnimationService, playerHealthService)
    {
        _playerAttackService = playerAttackService;
        _playerMovementService = playerMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerAnimationService.SetAnimationBool(PlayerAnimation.PlayerAnimationEnum.Idle,true);
        _playerAnimationService.ResetAttackCounter();
        Debug.Log("Idle State");
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
        else if (_playerSkill.IsUsing)
        {
            _playerStateService.SwitchState(_player.PlayerSkillState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _playerAnimationService.SetAnimationBool(PlayerAnimation.PlayerAnimationEnum.Idle, false);
    }
}
