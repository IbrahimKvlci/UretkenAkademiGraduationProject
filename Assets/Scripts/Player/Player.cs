using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [field:SerializeField] public PlayerSO PlayerSO { get; private set; }
    [field: SerializeField] public WeaponSO WeaponSO { get;  set; }
    [field: SerializeField] public PlayerSkill PlayerSkill { get; private set; }

    [SerializeField] private PlayerAnimation playerAnimation;
    [field:SerializeField] public PlayerAnimationHandler PlayerAnimationHandler { get; set; }
    [field:SerializeField] public PlayerTriggerCheck PlayerTriggerCheck { get; set; }

    public WeaponController WeaponController { get; set; }

    public Enemy EnemyTriggeredToBeAttacked { get; set; }

    public IPlayerHealthService PlayerHealthService {  get; private set; }
    public IPlayerMovementService PlayerMovementService { get; set; }
    public IPlayerGoldService PlayerGoldService { get; set; }

    private IPlayerStateService playerStateService;
    private IPlayerAttackService playerAttackService;
    private IPlayerAnimationService playerAnimationService;

    public IPlayerState PlayerIdleState { get; set; }
    public IPlayerState PlayerWalkState { get; set; }
    public IPlayerState PlayerRunState { get; set; }
    public IPlayerState PlayerStartingAttackState { get; set; }
    public IPlayerState PlayerAttackState { get; set; }
    public IPlayerState PlayerSkillState { get; set; }
    public IPlayerState PlayerDeathState { get; set; }



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
        PlayerGoldService= new PlayerGoldManager();
        
        PlayerIdleState = new PlayerIdleState(this, playerStateService, playerAttackService, PlayerMovementService, playerAnimationService,PlayerHealthService);
        PlayerWalkState = new PlayerWalkState(this, playerStateService,PlayerMovementService,playerAttackService, playerAnimationService, PlayerHealthService);
        PlayerStartingAttackState = new PlayerStartingAttackState(this, playerStateService, playerAnimationService, PlayerAnimationHandler, PlayerHealthService);
        PlayerAttackState=new PlayerAttackState(this,playerStateService,playerAttackService, playerAnimationService, PlayerAnimationHandler, PlayerHealthService);
        PlayerSkillState = new PlayerSkillState(this, playerStateService, playerAnimationService, PlayerHealthService);
        PlayerDeathState = new PlayerDeathState(this, playerStateService, playerAnimationService, PlayerHealthService);

        WeaponController=GetComponent<WeaponController>();
        
    }

    private void Start()
    {
        PlayerHealthService.IsAlive= true;
        PlayerHealthService.Health = PlayerSO.maxHealth;

        playerStateService.Initialize(PlayerIdleState);

        _gameInputSystem.OnPlayerInteract += gameInputSystem_OnPlayerInteract;
    }

    private void gameInputSystem_OnPlayerInteract(object sender, System.EventArgs e)
    {
        if(PlayerTriggerCheck.IsInteractableObjectTriggered(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }

    private void Update()
    {
        playerStateService.CurrentEnemyState.UpdateState();

    }

}
