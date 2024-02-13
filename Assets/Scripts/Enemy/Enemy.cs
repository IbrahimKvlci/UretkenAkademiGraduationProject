using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO { get;private set; }

    public bool IsPlayerTriggered { get; set; }

    private IEnemyStateService enemyStateService;
    private IEnemyMovementService enemyMovementService;
    private IEnemyChasePlayerService enemyChasePlayerService;

    public IEnemyState EnemyMoveState {  get; private set; }
    public IEnemyState EnemyChaseState{ get; private set; }

  
    private void Awake()
    {

        enemyMovementService = new EnemyMovement(this);
        enemyChasePlayerService = new EnemyChasePlayerManager(enemyMovementService);

        enemyStateService = new EnemyStateManager();
        EnemyMoveState = new EnemyMoveState(this, enemyStateService, enemyMovementService);
        EnemyChaseState = new EnemyChaseState(this, Player.Instance, enemyStateService, enemyChasePlayerService);
    }

    private void Start()
    {
        enemyStateService.Initialize(EnemyMoveState);
    }

    private void Update()
    {
        enemyStateService.CurrentEnemyState.UpdateState();
    }
}
