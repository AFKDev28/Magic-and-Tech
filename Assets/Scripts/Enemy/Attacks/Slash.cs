using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : AttackBase
{
    [SerializeField] private Transform attackPoint;

    public override void StartAttack(Transform targetPosi)
    {
        attackState = 0;
    }

    public override void EndAttack(Transform targetPosi)
    {
        StartCoroutine(AttackCD());
    }

    public override void OnExecutingAttack(Transform targetPosi)
    {
    }
    public override void ChangeAttackState()
    {
        base.ChangeAttackState();
        switch (attackState)
        {
            case 1:
                {
                    break;
                }
            default:
                break;
        }
    }

}
