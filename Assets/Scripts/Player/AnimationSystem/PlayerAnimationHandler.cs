using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public event EventHandler OnPlayerMeleeAttack;
    public event EventHandler OnPlayerMeleeAttackFinished;
    public event EventHandler OnPlayerDeathAnimationFinished;



    private void PlayerMeleeAttackEvent()
    {
        OnPlayerMeleeAttack?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerMeleeAttackFinishedEvent()
    {
        OnPlayerMeleeAttackFinished?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerDeathAnimationFinished()
    {
        OnPlayerDeathAnimationFinished?.Invoke(this, EventArgs.Empty);
    }
}
