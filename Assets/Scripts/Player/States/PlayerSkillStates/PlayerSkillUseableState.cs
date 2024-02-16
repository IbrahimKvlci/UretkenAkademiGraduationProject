using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillUseableState : PlayerSkillStateBase
{
    public PlayerSkillUseableState(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService) : base(skillBase, playerSkillStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_skillBase.IsSkillKeyPressed())
        {
            _skillBase.PlayerSkillStateService.SwitchState(_skillBase.PlayerSkillUseState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
