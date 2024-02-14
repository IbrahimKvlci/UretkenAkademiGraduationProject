using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [field:SerializeField] public PlayerSO PlayerSO { get; private set; }
    [field: SerializeField] public WeaponSO WeaponSO { get; private set; }


    public IPlayerHealthService PlayerHealthService {  get; private set; }

    private IPlayerStateService playerStateService;
    private IPlayerAttackService playerAttackService;
    private IPlayerMovementService playerMovementService;

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
        playerMovementService = new PlayerMovement(this, _gameInputSystem);
        PlayerHealthService = new PlayerHealthManager();
        
        PlayerIdleState = new PlayerIdleState(this, playerStateService, playerAttackService,playerMovementService);
        PlayerWalkState = new PlayerWalkState(this, playerStateService,playerMovementService,playerAttackService);
        PlayerRunState = new PlayerRunState(this, playerStateService);
        PlayerStartingAttackState = new PlayerStartingAttackState(this, playerStateService);
        PlayerAttackState=new PlayerAttackState(this,playerStateService);
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
