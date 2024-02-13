using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : IEnemyState
{
    protected Enemy _enemy;
    protected IEnemyStateService _enemyStateService;

    public EnemyStateBase(Enemy enemy, IEnemyStateService enemyStateService)
    {
        _enemy = enemy;
        _enemyStateService = enemyStateService;
    }

    public virtual void EnterState()
    {
        Debug.Log("EnterState");
    }

    public virtual void ExitState()
    {
        Debug.Log("ExitState");
    }

    public virtual void UpdateState()
    {
        Debug.Log("UpdateState");
    }
}
