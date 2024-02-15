using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : IPlayerSkillService
{
    public void UseSkill(SkillBaseSO skill,Player player)
    {
        skill.UseSkill(player);
    }
}
