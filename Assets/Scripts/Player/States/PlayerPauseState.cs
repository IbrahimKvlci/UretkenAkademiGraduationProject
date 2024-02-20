using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseState : PlayerStateBase
{


    public PlayerPauseState(Player player, IPlayerStateService playerStateService,IPlayerAnimationService playerAnimationService, IPlayerHealthService playerHealthService) : base(player, playerStateService, playerAnimationService, playerHealthService)
    {

    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_player.IsPlayerPaused)
        {
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
