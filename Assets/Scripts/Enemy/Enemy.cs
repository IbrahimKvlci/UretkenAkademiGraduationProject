using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO { get;private set; }

    public bool IsPlayerTriggered { get; set; }
    public bool IsPlayerTriggeredToBeAttacked { get; set; }

    private IEnemyMovementService enemyMovementService;
    private IEnemyStateService enemyStateService;
    private IEnemyChasePlayerService enemyChasePlayerService;
    private IEnemyAttackService enemyAttackService;

    public IEnemyState EnemyMoveState {  get; private set; }
    public IEnemyState EnemyChaseState{ get; private set; }
    public IEnemyState EnemyAttackState { get; private set; }
    

    private void Awake()
    {

        enemyMovementService = new EnemyMovement(this);
        enemyChasePlayerService = new EnemyChasePlayerManager(enemyMovementService);
        enemyAttackService = new EnemyAttackManager();

        enemyStateService = new EnemyStateManager();
        EnemyMoveState = new EnemyMoveState(this, enemyStateService, enemyMovementService);
        EnemyChaseState = new EnemyChaseState(this, Player.Instance, enemyStateService, enemyChasePlayerService);
        EnemyAttackState = new EnemyAttackState(this, enemyStateService, enemyAttackService,enemyMovementService);
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
