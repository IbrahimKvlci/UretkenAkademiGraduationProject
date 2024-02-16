using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSkillStateService
{
    public IPlayerSkillState CurrentPlayerSkillState { get; set; }

    void Initialize(IPlayerSkillState state);
    void SwitchState(IPlayerSkillState state);
}
