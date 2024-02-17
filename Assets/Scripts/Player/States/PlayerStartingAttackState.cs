using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingAttackState : PlayerStateBase
{


    private PlayerAnimationHandler _playerAnimationHandler;

    public PlayerStartingAttackState(Player player, IPlayerStateService playerStateService, IPlayerAnimationService playerAnimationService, PlayerAnimationHandler playerAnimationHandler) : base(player, playerStateService, playerAnimationService)
    {
        _playerAnimationHandler = playerAnimationHandler;
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerAnimationHandler.OnPlayerMeleeAttack += playerAnimationHandler_OnPlayerMeleeAttack;
        Debug.Log("Player Attack state");
        _playerAnimationService.SetAnimationTrigger(PlayerAnimation.PlayerAnimationEnum.IsAttacking);

        _playerSkill.CanUse = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_playerSkill.IsUsing)
        {
        _playerStateService.SwitchState(_player.PlayerSkillState);
        }
 
    }

    private void playerAnimationHandler_OnPlayerMeleeAttack(object sender, System.EventArgs e)
    {
        _playerStateService.SwitchState(_player.PlayerAttackState);
    }

    public override void ExitState()
    {
        base.ExitState();
        _playerAnimationHandler.OnPlayerMeleeAttack -= playerAnimationHandler_OnPlayerMeleeAttack;

    }
}
