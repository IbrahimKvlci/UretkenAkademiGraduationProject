 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBase : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Player player;

    [SerializeField] private int enemyCount;
    [SerializeField] private float range;

    private IEnemySpawnerService enemySpawnerService;

    private void Awake()
    {
        enemySpawnerService=new EnemySpawnerManager();
        enemy.Player = player;
    }

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            if(enemySpawnerService.RandomPosition(transform.position,range,out Vector3 result))
            {
                enemySpawnerService.SpawnEnemy(enemy,result);
            }

        }
    }
}
