using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DashSkill : SkillBase
{
    public override bool IsSkillKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.X);
    }
}
