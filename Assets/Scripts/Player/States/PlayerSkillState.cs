using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : PlayerStateBase
{
    IPlayerSkillService _playerSkillService;

    public PlayerSkillState(Player player, IPlayerStateService playerStateService,IPlayerSkillService playerSkillService) : base(player, playerStateService)
    {
        _playerSkillService = playerSkillService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
