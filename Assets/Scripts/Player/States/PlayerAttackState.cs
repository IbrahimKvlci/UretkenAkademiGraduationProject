using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    private float attackTimer;
    private bool canAttack;

    private IPlayerAttackService _playerAttackService;

    private PlayerAnimationHandler _playerAnimationHandler;

    public PlayerAttackState(Player player, IPlayerStateService playerStateService, IPlayerAttackService playerAttackService, IPlayerAnimationService playerAnimationService, PlayerAnimationHandler playerAnimationHandler) : base(player, playerStateService, playerAnimationService)
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
    }

    private void playerAnimationHandler_OnPlayerMeleeAttackFinished(object sender, System.EventArgs e)
    {
        _playerStateService.SwitchState(_player.PlayerIdleState);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.EnemyTriggeredToBeAttacked != null&&canAttack)
        {
            _playerAttackService.Attack(_player.EnemyTriggeredToBeAttacked, _player.WeaponSO);
            canAttack = false;
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
