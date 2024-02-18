using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSkillService
{
    void UseSkill(SkillBase skill);
    void PlayAnimation(SkillBase skill,PlayerAnimation playerAnimation);
}
