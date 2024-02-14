using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTriggerCheckService
{
    bool IsPlayerTriggered(Transform point,Enemy enemy,Player player,LayerMask layerMask);

    bool IsPlayerTriggeredToBePreparedForAttack(Transform point, Enemy enemy, Player player, LayerMask layerMask);

    bool IsPlayerTriggeredToBeAttacked(Transform point, Enemy enemy, Player player, LayerMask layerMask);
}
