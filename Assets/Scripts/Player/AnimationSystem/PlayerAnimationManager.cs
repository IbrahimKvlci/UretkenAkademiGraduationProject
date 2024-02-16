using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : IPlayerAnimationService
{
    private PlayerAnimation _playerAnimation;

    public PlayerAnimationManager(PlayerAnimation playerAnimation)
    {
        _playerAnimation = playerAnimation;
    }


    public void SetAnimationBool(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum, bool isRunning)
    {
        _playerAnimation.SetAnimationBool(playerAnimationEnum, isRunning);
    }

    public void SetAnimationTrigger(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum)
    {
        _playerAnimation.SetAnimationTrigger(playerAnimationEnum);
    }
}
