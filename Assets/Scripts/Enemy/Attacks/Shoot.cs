using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : AttackBase
{
    [SerializeField] private ProjectileController controller;
    public override void ExcuteAttack(Transform targetPosi)
    {
        ProjectileController temp = Instantiate(controller, transform.position, Quaternion.identity);
        temp.transform.LookAt(targetPosi);
    }
}
