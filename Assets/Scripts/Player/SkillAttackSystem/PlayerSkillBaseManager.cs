using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : IPlayerSkillService
{
    public void UseSkill(SkillBase skill)
    {
        if (skill.CanUse)
        {
            skill.SkillBaseSO.UseSkill();
        }
    }

}
