using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAnimationService
{
    void SetAnimationTrigger(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum);
    void SetAnimationBool(PlayerAnimation.PlayerAnimationEnum playerAnimationEnum,bool isRunning);
    void SetAttackCounter();
    void ResetAttackCounter();
}
