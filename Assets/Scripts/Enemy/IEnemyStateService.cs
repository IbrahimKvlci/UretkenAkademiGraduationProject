using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateService
{
    void SwitchState(IEnemyState state);
}
