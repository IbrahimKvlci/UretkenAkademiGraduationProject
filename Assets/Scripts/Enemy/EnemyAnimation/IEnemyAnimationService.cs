using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAnimationService
{
    void TriggerDeath();
    void TriggerAttack();
    void TriggerTakeDamage();
    void SetChasing(bool value);
    void SetStand(bool value);
}
