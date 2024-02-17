using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : PlayerStateBase
{


    public PlayerSkillState(Player player, IPlayerStateService playerStateService,IPlayerAnimationService playerAnimationService) : base(player, playerStateService, playerAnimationService)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Player Skill State");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_playerSkill.IsUsing)
        {
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
