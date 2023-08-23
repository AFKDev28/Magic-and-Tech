using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : AttackBase
{
    [SerializeField] private ProjectileController controller;

    public override void ChangeAttackState()
    {
       
    }

    public override void StartAttack(Transform targetPosi)
    {
        ProjectileController temp = Instantiate(controller, transform.position, Quaternion.identity);
        temp.transform.LookAt(targetPosi);
    }

    public override void EndAttack(Transform targetPosi)
    {
        StartCoroutine(AttackCD());
    }

    public override void OnExecutingAttack(Transform targetPosi)
    {

    }
}
