using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSkillService
{
    void UseSkill(SkillBaseSO skill, Player player);
}
