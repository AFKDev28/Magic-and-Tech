using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    [SerializeField] public bool hasAni = false;
    [SerializeField] public string aniTrigger = "";

    [SerializeField] public float attackCD;
    [SerializeField] public float attackDuration;
    [SerializeField] protected bool readyToAttack = true;

    [SerializeField] protected bool haveRange;
    [SerializeField] protected float minRange;
    [SerializeField] protected float maxRange;

    [SerializeField] public bool stopMovBeh = false;

    protected int attackState;

    public Color gizmosColor;

    public virtual bool CanExcuteAttack(Vector3 targetPosi)
    {
        if (!readyToAttack || !OtherConditions(targetPosi)) { return false; }  
        
        if (!haveRange) { return true; }

        float dis = Vector3.Distance(transform.position, targetPosi);


        if (IsInDistance(dis))
            return true;
        return false;
    }

    public virtual bool OtherConditions(Vector3 targetPosi)
    {
        return true;
    }

    private bool IsInDistance(float dis)
    {
        if (dis < maxRange && dis > minRange)
            return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        if (haveRange)
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawSphere(transform.position, minRange);
            Gizmos.DrawSphere(transform.position, maxRange);
        }
    }

    public abstract void OnExecutingAttack(Transform targetPosi);
    public abstract void StartAttack(Transform targetPosi);
    public abstract void EndAttack(Transform targetPosi);

    public virtual void ChangeAttackState()
    {
        attackState++;
    }
   

    protected IEnumerator AttackCD()
    {
        yield return new WaitForSeconds(attackCD);
        readyToAttack = true;
    }

}
