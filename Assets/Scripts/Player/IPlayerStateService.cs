using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateService
{
    public IPlayerState CurrentEnemyState { get; set; }

    void Initialize(IPlayerState state);
    void SwitchState(IPlayerState state);
}
