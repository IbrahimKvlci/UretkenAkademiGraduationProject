using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSkillState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
