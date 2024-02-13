using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerCheckManager : IEnemyTriggerCheckService
{

    public bool IsPlayerTriggered(Transform point,Enemy enemy,Player player, LayerMask layerMask)
    {
        return Physics.CheckSphere(point.position, enemy.EnemySO.chaseRange, layerMask);
    }

    public bool IsPlayerTriggeredToBeAttacked(Transform point,Enemy enemy, Player player, LayerMask layerMask)
    {
        return Physics.Raycast(point.position, point.forward,enemy.EnemySO.attackRange, layerMask);
    }
}
