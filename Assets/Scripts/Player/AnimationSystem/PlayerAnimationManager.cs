using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAnimation;

public class PlayerAnimationManager : IPlayerAnimationService
{
    private PlayerAnimation _playerAnimation;

    public PlayerAnimationManager(PlayerAnimation playerAnimation)
    {
        _playerAnimation = playerAnimation;
    }

    public void ResetAttackCounter()
    {
        _playerAnimation.ResetAttackCounter();
    }

    public void SetAnimationBool(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum, bool isRunning)
    {
        _playerAnimation.SetAnimationBool(playerAnimationEnum, isRunning);
    }

    public void SetAnimationTrigger(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum)
    {
        _playerAnimation.SetAnimationTrigger(playerAnimationEnum);
    }

    public void SetAttackCounter()
    {
        _playerAnimation.SetAttackCounter();
    }
}
