using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemySpawnerService
{
    void SpawnEnemy(Enemy enemy,Vector3 position);

    bool RandomPosition(Vector3 center, float range, out Vector3 result);
}
