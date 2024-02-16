using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillUseState : PlayerSkillStateBase
{
    public PlayerSkillUseState(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService) : base(skillBase, playerSkillStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _skillBase.PlayerSkill.PlayerSkillService.UseSkill(_skillBase);
        _playerSkillStateService.SwitchState(_skillBase.PlayerSkillCooldownState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
