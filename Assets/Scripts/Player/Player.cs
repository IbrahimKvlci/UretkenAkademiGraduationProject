using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [field:SerializeField] public PlayerSO PlayerSO { get; private set; }
    [field: SerializeField] public WeaponSO WeaponSO { get; private set; }
    [field: SerializeField] public PlayerSkill PlayerSkill { get; private set; }

    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerAnimationHandler playerAnimationHandler;


    public Enemy EnemyTriggeredToBeAttacked { get; set; }

    public IPlayerHealthService PlayerHealthService {  get; private set; }
    public IPlayerMovementService PlayerMovementService { get; set; }

    private IPlayerStateService playerStateService;
    private IPlayerAttackService playerAttackService;
    private IPlayerAnimationService playerAnimationService;

    public IPlayerState PlayerIdleState { get; set; }
    public IPlayerState PlayerWalkState { get; set; }
    public IPlayerState PlayerRunState { get; set; }
    public IPlayerState PlayerStartingAttackState { get; set; }
    public IPlayerState PlayerAttackState { get; set; }
    public IPlayerState PlayerSkillState { get; set; }


    private IGameInputSystem _gameInputSystem;

    [Inject]
    public void Construct(IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one player");
        }

        Instance = this;


        playerAttackService = new PlayerAttackManager(_gameInputSystem);
        playerStateService = new PlayerStateManager();
        playerAnimationService = new PlayerAnimationManager(playerAnimation);
        PlayerMovementService = new PlayerMovement(this, _gameInputSystem);
        PlayerHealthService = new PlayerHealthManager();
        
        PlayerIdleState = new PlayerIdleState(this, playerStateService, playerAttackService, PlayerMovementService, playerAnimationService);
        PlayerWalkState = new PlayerWalkState(this, playerStateService,PlayerMovementService,playerAttackService, playerAnimationService);
        PlayerStartingAttackState = new PlayerStartingAttackState(this, playerStateService, playerAnimationService, playerAnimationHandler);
        PlayerAttackState=new PlayerAttackState(this,playerStateService,playerAttackService, playerAnimationService, playerAnimationHandler);
        PlayerSkillState = new PlayerSkillState(this, playerStateService, playerAnimationService);
        
    }

    private void Start()
    {
        PlayerHealthService.Health = PlayerSO.maxHealth;

        playerStateService.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        playerStateService.CurrentEnemyState.UpdateState();

    }

}
