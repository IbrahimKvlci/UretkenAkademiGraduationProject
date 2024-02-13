using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyTriggerCheck : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    [SerializeField] LayerMask layerMask;

    private IEnemyTriggerCheckService _enemyTriggerCheckService;

    [Inject]
    public void Construct(IEnemyTriggerCheckService enemyTriggerCheckService)
    {
        _enemyTriggerCheckService = enemyTriggerCheckService;
    }

    private void Update()
    {
        enemy.IsPlayerTriggered =_enemyTriggerCheckService.IsPlayerTriggered(enemy, Player.Instance, layerMask);
    }
}
