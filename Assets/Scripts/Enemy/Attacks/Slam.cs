using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam : AttackBase
{
    [SerializeField] private Transform parentTransform;
    private Vector3 target;
    [SerializeField] private float jumpHeight;
    private float totalX, p0, p1, p2, p3;
    Vector3 velocity;

    public override void ChangeAttackState()
    {
    }

    public override void StartAttack(Transform targetPosi)
    {
        readyToAttack = false;


        target = targetPosi.position;
        totalX =MathF.Abs(target.x - parentTransform.position.x);
        p0 = transform.position.y;
        p3 = target.y;
        p1  = p0 + jumpHeight;
        p2 = p3 + jumpHeight;
        velocity = (target - parentTransform.position) / attackDuration;    
    }

    public override void EndAttack(Transform targetPosi)
    {
        parentTransform.position = target;
        StartCoroutine(AttackCD());

    }

    public override void OnExecutingAttack(Transform targetPosi)
    {

        // controrl Y position by bezier curve 4 point
        float x =MathF.Abs( target.x - (parentTransform.position.x)) ;
        float t = 1- x/ totalX;

        float yPosi = Mathf.Pow((1 - t), 3) * p0 + 3 * t * Mathf.Pow(1 - t, 2) * p1 + 3 * Mathf.Pow(t, 2) * (1 - t) * p2 + Mathf.Pow(t, 3) * p3;
        Debug.Log(yPosi);
        parentTransform.position = new Vector3(parentTransform.position.x + velocity.x * Time.fixedDeltaTime
            , yPosi,
            parentTransform.position.z + velocity.z * Time.fixedDeltaTime);

        Debug.Log(parentTransform.position);
    }

}
