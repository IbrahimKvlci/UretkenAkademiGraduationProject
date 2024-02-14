using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : IPlayerStateService
{
    public IPlayerState CurrentEnemyState { get; set; }

    public void Initialize(IPlayerState state)
    {
        CurrentEnemyState = state;
        state.EnterState();
    }

    public void SwitchState(IPlayerState state)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = state;
        CurrentEnemyState.EnterState();
    }
}
