using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : AttackBase
{
    [SerializeField] private Transform parentTransform;
    Vector3 velocity;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float dashTime, dashSpeed;
    [SerializeField] private Transform raycastPosition;
    public override bool OtherConditions(Vector3 targetPosi)
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, targetPosi, Color.red);


        if (Physics.Raycast(raycastPosition.position,
            targetPosi - raycastPosition.position, out hit, dashTime * dashSpeed, mask)
            )
        {
            return false;
        }
        return true;
    }
    public override void StartAttack(Transform targetPosi)
    {
        attackState = 0;
        readyToAttack = false;
        velocity = (targetPosi.position - parentTransform.position) .normalized * dashSpeed;
    }

    public override void EndAttack(Transform targetPosi)
    {
        StartCoroutine(AttackCD());
    }

    public override void OnExecutingAttack(Transform targetPosi)
    {
        switch (attackState)
        {
            case 1:
                {
                    parentTransform.position = new Vector3(parentTransform.position.x + velocity.x * Time.fixedDeltaTime
                                                , parentTransform.position.y,
                                                parentTransform.position.z + velocity.z * Time.fixedDeltaTime);

                    break;
                }
            default: break;
        }
    }
}
