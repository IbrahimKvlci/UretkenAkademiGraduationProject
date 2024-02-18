using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTriggerCheckManager : IPlayerTriggerCheckService
{
    public bool IsEnemiesTriggeredToBeAttacked(Transform point, out List<Enemy> enemies, float length, LayerMask layerMask)
    {
        List<Enemy> enemiesList = new List<Enemy>();
        foreach (var item in Physics.SphereCastAll(point.position, length, point.forward, length, layerMask))
        {
            enemiesList.Add(item.transform.GetComponent<Enemy>());
        }

        enemies = enemiesList;
        return enemies.Count > 0;
    }

    public bool IsEnemyTriggeredToBeAttacked(Transform point, out Enemy enemy, float length, LayerMask layerMask)
    {
        if(Physics.Raycast(point.position, point.forward,out RaycastHit hitInfo, length, layerMask))
        {
            enemy=hitInfo.transform.GetComponent<Enemy>();
            return true;
        }
        enemy= null;
        return false;
    }
}
