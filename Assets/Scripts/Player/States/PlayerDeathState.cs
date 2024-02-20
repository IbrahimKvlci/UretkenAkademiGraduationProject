using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerStateBase
{


    public PlayerDeathState(Player player, IPlayerStateService playerStateService,IPlayerAnimationService playerAnimationService, IPlayerHealthService playerHealthService) : base(player, playerStateService, playerAnimationService, playerHealthService)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        _player.PlayerAnimationHandler.OnPlayerDeathAnimationFinished += PlayerAnimationHandler_OnPlayerDeathAnimationFinished;

        _playerAnimationService.SetAnimationTrigger(PlayerAnimation.PlayerAnimationEnum.Death);
    }

    private void PlayerAnimationHandler_OnPlayerDeathAnimationFinished(object sender, System.EventArgs e)
    {
        GameManager.Instance.TogglePause();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }

    public override void ExitState()
    {
        base.ExitState();
        _player.PlayerAnimationHandler.OnPlayerDeathAnimationFinished -= PlayerAnimationHandler_OnPlayerDeathAnimationFinished;

    }
}
