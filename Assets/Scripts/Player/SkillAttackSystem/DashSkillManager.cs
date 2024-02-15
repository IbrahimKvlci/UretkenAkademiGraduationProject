
using System;
using UnityEngine;

public class DashSkillManager : ISkillService
{
   

    public void UseSkill(SkillBaseSO skill,Player player)
    {
        DashSkillSO dashSkillSO=(DashSkillSO)skill;

       player.PlayerMovementService.Dash(dashSkillSO.speed);
    }
}