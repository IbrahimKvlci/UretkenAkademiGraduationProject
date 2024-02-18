using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SkillBase:MonoBehaviour
{
    [field:SerializeField] public SkillBaseSO SkillBaseSO { get; set; }
    [field: SerializeField] public PlayerSkill PlayerSkill { get; set; }


    [field: SerializeField]  public bool CanUse { get; set; }

    public IPlayerSkillStateService PlayerSkillStateService { get; set; }

    public IPlayerSkillState PlayerSkillUseableState {  get; set; }
    public IPlayerSkillState PlayerSkillUseState { get; set; }
    public IPlayerSkillState PlayerSkillCooldownState { get; set; }
    public IPlayerSkillState PlayerSkillAnimationState { get; set; }

    protected IGameInputSystem _gameInputSystem;

    //[Inject]
    //public void Construct(IGameInputSystem gameInputSystem)
    //{
    //    _gameInputSystem = gameInputSystem;
    //}

    protected virtual void Awake()
    {
        _gameInputSystem = FindObjectOfType<GameInputManager>(); 

        PlayerSkillStateService = new PlayerSkillStateManager();
        Debug.Log("Created!");
        PlayerSkillUseableState = new PlayerSkillUseableState(this, PlayerSkillStateService,PlayerSkill);
        PlayerSkillUseState = new PlayerSkillUseState(this, PlayerSkillStateService);
        PlayerSkillCooldownState = new PlayerSkillCooldownState(this, PlayerSkillStateService);
        PlayerSkillAnimationState=new PlayerSkillAnimationState(this,PlayerSkillStateService);
    }

    private void Start()
    {
        CanUse = false;
    }

    public virtual bool IsSkillKeyPressed()
    {
        throw new NotImplementedException();
    }
}
