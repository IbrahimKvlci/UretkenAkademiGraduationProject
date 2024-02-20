using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase:IPlayerState
{
    protected Player _player;
    protected PlayerSkill _playerSkill;
    protected IPlayerStateService _playerStateService;
    protected IPlayerAnimationService _playerAnimationService;
    protected IPlayerHealthService _playerHealthService;

    public PlayerStateBase(Player player, IPlayerStateService playerStateService,IPlayerAnimationService playerAnimationService,IPlayerHealthService playerHealthService)
    {
        _player = player;
        _playerSkill = _player.PlayerSkill;
        _playerStateService = playerStateService;
        _playerAnimationService = playerAnimationService;
        _playerHealthService = playerHealthService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
        if(this is not PlayerDeathState)
        {
            if (!_playerHealthService.IsAlive)
            {
                _playerStateService.SwitchState(_player.PlayerDeathState);
            }
        }

        if(this is not PlayerPauseState)
        {
            //State is not pause state
            if (_player.IsPlayerPaused)
            {
                _playerStateService.SwitchState(_player.PlayerPauseState);
            }
        }
    }
}
