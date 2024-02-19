using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerTriggerCheckService
{

    bool IsEnemyTriggeredToBeAttacked(Transform point, out Enemy enemy, float length, LayerMask layerMask);
    bool IsEnemiesTriggeredToBeAttacked(Transform point,out List<Enemy> enemies, float length,LayerMask layerMask);

    bool IsInteractableObjectTriggered(Transform point, out IInteractable interactable, float length);
}
