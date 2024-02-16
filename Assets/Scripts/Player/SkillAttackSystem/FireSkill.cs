using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireSkill : SkillBase
{
   

    public override bool IsSkillKeyPressed()
    {
        return _gameInputSystem.OnSkillButtonPressed();
    }
}
