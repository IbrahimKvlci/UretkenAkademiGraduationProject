using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private float attackTimer;
    private bool canAttack;

    private IPlayerAttackService _playerAttackService;

    private PlayerAnimationHandler _playerAnimationHandler;

    public PlayerAttackState(Player player, IPlayerStateService playerStateService, IPlayerAttackService playerAttackService, IPlayerAnimationService playerAnimationService, PlayerAnimationHandler playerAnimationHandler, IPlayerHealthService playerHealthService) : base(player, playerStateService, playerAnimationService, playerHealthService)
    {
        _playerAttackService = playerAttackService;
        _playerAnimationHandler = playerAnimationHandler;
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerAnimationHandler.OnPlayerMeleeAttackFinished += playerAnimationHandler_OnPlayerMeleeAttackFinished;
        attackTimer = 0;
        canAttack = true;
        _playerSkill.CanUse = false;

        if(_player.EnemyTriggeredToBeAttacked != null&&canAttack)
        {
            _playerAttackService.Attack(_player.EnemyTriggeredToBeAttacked, _player.WeaponSO);
            Debug.Log(this);
            canAttack = false;
        }
        _playerSkill.CanUse = true;
    }

    private void playerAnimationHandler_OnPlayerMeleeAttackFinished(object sender, System.EventArgs e)
    {
        _playerStateService.SwitchState(_player.PlayerIdleState);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_playerSkill.IsUsing)
        {
            _playerStateService.SwitchState(_player.PlayerSkillState);
        }

        if (_playerAttackService.IsAttacking())
        {
            _playerAnimationService.SetAttackCounter();
            _playerStateService.SwitchState(_player.PlayerStartingAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _playerAnimationHandler.OnPlayerMeleeAttackFinished -= playerAnimationHandler_OnPlayerMeleeAttackFinished;
        _playerSkill.CanUse = true;
    }
}
