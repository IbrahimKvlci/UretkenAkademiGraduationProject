using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : IPlayerSkillService
{
    public void PlayAnimation(SkillBase skill, PlayerAnimation playerAnimation)
    {
        skill.SkillBaseSO.SkillService.PlayAnimation(skill.SkillBaseSO,playerAnimation);
    }

    public void UseSkill(SkillBase skill)
    {
        if (skill.CanUse)
        {
            skill.SkillBaseSO.UseSkill();
        }
    }

}
