using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillStateBase : IPlayerSkillState
{
    protected SkillBase _skillBase;
    protected IPlayerSkillStateService _playerSkillStateService;

    public PlayerSkillStateBase(SkillBase skillBase, IPlayerSkillStateService playerSkillStateService)
    {
        _skillBase = skillBase;
        _playerSkillStateService = playerSkillStateService;
    }

    public virtual void EnterState()
    {
        Debug.Log($"{_skillBase.name}");
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
