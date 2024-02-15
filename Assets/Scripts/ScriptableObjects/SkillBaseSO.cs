using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBaseSO : ScriptableObject
{
    public float cooldown;

    public ISkillService SkillService { get; set; }

    public virtual void UseSkill(Player player)
    {

    }

}
