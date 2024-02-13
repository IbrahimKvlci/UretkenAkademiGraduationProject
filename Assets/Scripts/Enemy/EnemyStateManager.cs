using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour, IEnemyStateService
{
    private IEnemyState currentEnemyState;

    private void Start()
    {
        currentEnemyState.EnterState(this);
    }

    private void Update()
    {
        currentEnemyState.UpdateState(this);
    }

    public void SwitchState(IEnemyState state)
    {
        currentEnemyState = state;
    }
}
