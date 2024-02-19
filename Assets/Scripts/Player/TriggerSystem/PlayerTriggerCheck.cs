using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTriggerCheck : MonoBehaviour
{
    public event EventHandler<OnInteractableObjectTriggeredEventArgs> OnInteractableObjectTriggered;
    public class OnInteractableObjectTriggeredEventArgs : EventArgs
    {
        public IInteractable interactable { get; set; }
    }

    public event EventHandler OnInteractableObjectNotTriggered;

    [SerializeField] private Player player;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range;

    private bool eventCheckedInteractable;

    public IPlayerTriggerCheckService PlayerTriggerCheckService {  get; private set; }

    [Inject]
    public void Construct(IPlayerTriggerCheckService playerTriggerCheckService)
    {
        PlayerTriggerCheckService = playerTriggerCheckService;
    }

    private void Start()
    {
        eventCheckedInteractable = false;
    }

    private void Update()
    {
        if(PlayerTriggerCheckService.IsEnemyTriggeredToBeAttacked(transform,out Enemy enemy, player.WeaponSO.length, layerMask))
        {
            player.EnemyTriggeredToBeAttacked= enemy;
        }
        else
        {
            player.EnemyTriggeredToBeAttacked = null;
        }

        //Check any interactable triggered
        if(IsInteractableObjectTriggered(out IInteractable interactable)&&!eventCheckedInteractable)
        {
            OnInteractableObjectTriggered?.Invoke(this, new OnInteractableObjectTriggeredEventArgs
            {
                interactable= interactable
            });
            eventCheckedInteractable = true;

        }
        else if(!IsInteractableObjectTriggered(out IInteractable interactable1) && eventCheckedInteractable)
        {
            OnInteractableObjectNotTriggered?.Invoke(this, EventArgs.Empty);
            eventCheckedInteractable= false;
        }
    }

    public bool IsEnemiesTriggeredToBeAttacked(out List<Enemy> enemies,float range)
    {
        return PlayerTriggerCheckService.IsEnemiesTriggeredToBeAttacked(transform, out enemies, range, layerMask);
    }

    public bool IsInteractableObjectTriggered(out IInteractable interactable)
    {
        return PlayerTriggerCheckService.IsInteractableObjectTriggered(transform, out interactable,range);
    }
}
