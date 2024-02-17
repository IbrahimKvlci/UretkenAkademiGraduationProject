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
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
