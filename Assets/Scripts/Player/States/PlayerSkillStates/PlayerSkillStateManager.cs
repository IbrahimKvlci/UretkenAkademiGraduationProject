using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillStateManager : IPlayerSkillStateService
{
    public IPlayerSkillState CurrentPlayerSkillState { get; set; }

    public void Initialize(IPlayerSkillState state)
    {
        CurrentPlayerSkillState = state;
        state.EnterState();
    }

    public void SwitchState(IPlayerSkillState state)
    {
        CurrentPlayerSkillState.ExitState();
        CurrentPlayerSkillState = state;
        CurrentPlayerSkillState.EnterState();
    }
}
