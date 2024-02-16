
using System;
using UnityEngine;

public class DashSkillManager : ISkillService
{
   

    public void UseSkill(SkillBaseSO skill)
    {
        DashSkillSO dashSkillSO=(DashSkillSO)skill;

        Player.Instance.PlayerMovementService.Dash(dashSkillSO.speed);
    }
}