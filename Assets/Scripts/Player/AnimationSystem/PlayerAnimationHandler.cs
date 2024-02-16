using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    public event EventHandler OnPlayerMeleeAttack;
    public event EventHandler OnPlayerMeleeAttackFinished;


    private void PlayerMeleeAttackEvent()
    {
        OnPlayerMeleeAttack?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerMeleeAttackFinishedEvent()
    {
        OnPlayerMeleeAttackFinished?.Invoke(this, EventArgs.Empty);
    }
}
