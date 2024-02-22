using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrepareAttackState : EnemyStateBase
{
    private float enemyAttackTimer;

    private IEnemyAttackService _enemyAttackService;
    private IEnemyMovementService _enemyMovementService;

    public EnemyPrepareAttackState(Enemy enemy, IEnemyStateService enemyStateService,IEnemyAttackService enemyAttackService,IEnemyMovementService enemyMovementService) : base(enemy, enemyStateService)
    {
        _enemyAttackService = enemyAttackService;
        _enemyMovementService = enemyMovementService;
    }


    public override void EnterState()
    {
        base.EnterState();

        _enemyMovementService.CanMove = false;
        _enemy.EnemyAnimation.EnemyAnimationService.SetStand(true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Vector3 enemyNewForward = Player.Instance.transform.position - _enemy.transform.position;
        _enemy.transform.forward = Vector3.Slerp(_enemy.transform.forward, enemyNewForward, _enemy.EnemySO.rotationSpeed*Time.deltaTime).normalized;
        enemyAttackTimer += Time.deltaTime;
        if ((enemyAttackTimer > _enemy.EnemySO.attackSpeed)&&_enemy.IsPlayerTriggeredToBeAttacked)
        {
            enemyAttackTimer = 0;
            _enemyStateService.SwitchState(_enemy.EnemyAttackState);
        }

        if (!_enemy.IsPlayerTriggeredToBePreparedForAttack)
        {
            _enemyStateService.SwitchState(_enemy.EnemyChaseState);
        }
        if (_enemy.IsDead)
        {
            _enemyStateService.SwitchState(_enemy.EnemyDeathState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log("ExitAttack");
        _enemy.EnemyAnimation.EnemyAnimationService.SetStand(false);

        _enemyMovementService.CanMove = true;
    }

}
