using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject
{
    public float cooldown;

    public ISkillService SkillService { get; set; }
    public IPlayerSkillStateService PlayerSkillStateService { get; set; }
    public IPlayerSkillState PlayerSkillUseableState { get; set; }
    public IPlayerSkillState PlayerSkillUseState { get; set; }
    public IPlayerSkillState PlayerSkillCooldownState { get; set; }

    public virtual void UseSkill()
    {

    }

}
