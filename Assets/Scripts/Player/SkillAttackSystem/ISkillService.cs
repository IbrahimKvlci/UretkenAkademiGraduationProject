using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillService
{
    event EventHandler OnSkillUsed;
    

    void UseSkill(SkillBaseSO skill);
}
