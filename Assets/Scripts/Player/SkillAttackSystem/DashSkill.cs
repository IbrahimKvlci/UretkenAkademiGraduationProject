using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DashSkill : SkillBase
{
    protected override void Awake()
    {
        SkillBaseSO.SkillService=new DashSkillManager();
        base.Awake();
    }

    public override bool IsSkillKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.X);
    }
}
