using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO { get;private set; }
    [field: SerializeField] public EnemyAnimationBase EnemyAnimation { get; private set; }
    [SerializeField] private Player player;

    public bool IsDead { get; set; }

    public bool IsPlayerTriggered { get; set; }
    public bool IsPlayerTriggeredToBePreparedForAttack { get; set; }
    public bool IsPlayerTriggeredToBeAttacked { get; set; }

    public IEnemyMovementService EnemyMovementService { get; private set; }
    private IEnemyStateService enemyStateService;
    private IEnemyChasePlayerService enemyChasePlayerService;
    private IEnemyAttackService enemyAttackService;

    public IEnemyHealthService EnemyHealthService { get; private set; }

    public IEnemyState EnemyMoveState {  get; private set; }
    public IEnemyState EnemyChaseState{ get; private set; }
    public IEnemyState EnemyPreapareAttackState { get; private set; }
    public IEnemyState EnemyAttackState { get; private set; }
    public IEnemyState EnemyDeathState { get; private set; }


    private void Awake()
    {

        EnemyMovementService = new EnemyMovement(this);
        enemyChasePlayerService = new EnemyChasePlayerManager(EnemyMovementService);
        enemyAttackService = new EnemyAttackManager();

        EnemyHealthService = new EnemyHealthManager();

        enemyStateService = new EnemyStateManager();
        EnemyMoveState = new EnemyMoveState(this, enemyStateService, EnemyMovementService);
        EnemyChaseState = new EnemyChaseState(this, player, enemyStateService, enemyChasePlayerService);
        EnemyPreapareAttackState = new EnemyPrepareAttackState(this, enemyStateService, enemyAttackService,EnemyMovementService);
        EnemyAttackState=new EnemyAttackState(this,enemyStateService,enemyAttackService);
        EnemyDeathState = new EnemyDeathState(this, enemyStateService, EnemyMovementService);
    }

    private void Start()
    {
        IsDead= false;
        EnemyHealthService.Health = EnemySO.maxHealth;
        enemyStateService.Initialize(EnemyMoveState);
    }

    private void Update()
    {
        enemyStateService.CurrentEnemyState.UpdateState();
    }
}
