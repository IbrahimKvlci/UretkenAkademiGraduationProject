using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void EnterState(IEnemyStateService enemyStateManager);
    void UpdateState(IEnemyStateService enemyStateManager);
    void ExitState(IEnemyStateService enemyStateManager);
}
