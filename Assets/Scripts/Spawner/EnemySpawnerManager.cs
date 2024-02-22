using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawnerManager : IEnemySpawnerService
{
    public bool RandomPosition(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;

                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public void SpawnEnemy(Enemy enemy, Vector3 position)
    {
        Enemy spawnedEnemy=GameObject.Instantiate(enemy,position,Quaternion.identity);
    }
}
