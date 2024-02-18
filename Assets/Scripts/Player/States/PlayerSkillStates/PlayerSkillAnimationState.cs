using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillAnimationState : PlayerSkillStateBase
{
    private float timer;

    public PlayerSkillAnimationState(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService) : base(skillBase, playerSkillStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
        //Play Animation
        _skillBase.PlayerSkill.PlayerSkillService.PlayAnimation(_skillBase, _skillBase.PlayerSkill.PlayerAnimation);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        timer += Time.deltaTime;
        if(timer>_skillBase.SkillBaseSO.timeToUse)
        {
            //UseSkill
            _playerSkillStateService.SwitchState(_skillBase.PlayerSkillUseState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
