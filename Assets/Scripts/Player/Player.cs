using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [field:SerializeField] public PlayerSO PlayerSO { get; private set; }
    [field: SerializeField] public WeaponSO WeaponSO { get; private set; }
    [field: SerializeField] public SkillBaseSO SkillBaseSO { get; private set; }
    [field: SerializeField] public SkillBaseSO SkillBaseSO1 { get; private set; }



    public Enemy EnemyTriggeredToBeAttacked { get; set; }

    public IPlayerHealthService PlayerHealthService {  get; private set; }
    public IPlayerMovementService PlayerMovementService { get; set; }

    private IPlayerStateService playerStateService;
    private IPlayerAttackService playerAttackService;
    private IPlayerSkillService playerSkillService;

    public IPlayerState PlayerIdleState { get; set; }
    public IPlayerState PlayerWalkState { get; set; }
    public IPlayerState PlayerRunState { get; set; }
    public IPlayerState PlayerStartingAttackState { get; set; }
    public IPlayerState PlayerAttackState { get; set; }


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
        PlayerMovementService = new PlayerMovement(this, _gameInputSystem);
        playerSkillService=new PlayerSkillManager();
        PlayerHealthService = new PlayerHealthManager();
        
        PlayerIdleState = new PlayerIdleState(this, playerStateService, playerAttackService, PlayerMovementService);
        PlayerWalkState = new PlayerWalkState(this, playerStateService,PlayerMovementService,playerAttackService);
        PlayerRunState = new PlayerRunState(this, playerStateService);
        PlayerStartingAttackState = new PlayerStartingAttackState(this, playerStateService);
        PlayerAttackState=new PlayerAttackState(this,playerStateService,playerAttackService);
    }

    private void Start()
    {
        PlayerHealthService.Health = PlayerSO.maxHealth;

        playerStateService.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        playerStateService.CurrentEnemyState.UpdateState();

        if (Input.GetKeyDown(KeyCode.X))
        {
            playerSkillService.UseSkill(SkillBaseSO,this);
        }
        else if(Input.GetKeyDown(KeyCode.Y))
        {
            playerSkillService.UseSkill(SkillBaseSO1, this);
        }
    }

}
