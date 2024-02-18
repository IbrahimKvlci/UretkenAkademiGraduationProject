using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillUseableState : PlayerSkillStateBase
{
    private PlayerSkill _playerSkill;


    public PlayerSkillUseableState(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService,PlayerSkill playerSkill) : base(skillBase, playerSkillStateService)
    {
        _playerSkill= playerSkill;  
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_playerSkill.CanUse)
        {
            if (_skillBase.IsSkillKeyPressed() && _skillBase.CanUse)
            {
                _skillBase.PlayerSkillStateService.SwitchState(_skillBase.PlayerSkillAnimationState);
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
