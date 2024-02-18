using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FireSkill : SkillBase
{
    [SerializeField] private PlayerTriggerCheck playerTriggerCheck;

    protected override void Awake()
    {
        SkillBaseSO.SkillService = new FireSkillManager(playerTriggerCheck);

        base.Awake();
    }

    public override bool IsSkillKeyPressed()
    {
        return _gameInputSystem.OnSkillButtonPressed();
    }
}
