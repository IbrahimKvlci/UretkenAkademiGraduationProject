using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase:IPlayerState
{
    protected Player _player;
    protected PlayerSkill _playerSkill;
    protected IPlayerStateService _playerStateService;
    protected IPlayerAnimationService _playerAnimationService;

    public PlayerStateBase(Player player, IPlayerStateService playerStateService,IPlayerAnimationService playerAnimationService)
    {
        _player = player;
        _playerSkill = _player.PlayerSkill;
        _playerStateService = playerStateService;
        _playerAnimationService = playerAnimationService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
