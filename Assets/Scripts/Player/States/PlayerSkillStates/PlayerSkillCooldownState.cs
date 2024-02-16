using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillCooldownState : PlayerSkillStateBase
{
    private float timer;

    public PlayerSkillCooldownState(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService) : base(skillBase, playerSkillStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer+= Time.deltaTime;
        if (timer >= _skillBase.SkillBaseSO.cooldown)
        {
            timer = 0;
            _playerSkillStateService.SwitchState(_skillBase.PlayerSkillUseableState);
        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
