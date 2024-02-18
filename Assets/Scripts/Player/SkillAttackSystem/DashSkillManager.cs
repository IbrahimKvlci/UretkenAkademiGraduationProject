
using System;
using UnityEngine;

public class DashSkillManager : ISkillService
{
    public event EventHandler OnSkillUsed;

    public void PlayAnimation(SkillBaseSO skill, PlayerAnimation playerAnimation)
    {
        playerAnimation.DashSkillAnimation();
    }

    public void UseSkill(SkillBaseSO skill)
    {
        OnSkillUsed?.Invoke(this, EventArgs.Empty);

        DashSkillSO dashSkillSO = (DashSkillSO)skill;

        Player.Instance.PlayerMovementService.Dash(dashSkillSO.speed);

    }
}