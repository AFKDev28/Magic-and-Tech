using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private List<AttackBase> attacks;

    [SerializeField]  private Animator animator;
    [SerializeField] private EnemyMovement movBeh;

    [SerializeField] private Transform attackTarget;
    private AttackBase currentAttack;
    
    private bool isAttacking;

    private void OnEnable()
    {
        GetListAttacks();
    }

    public void GetListAttacks()
    {
        AttackBase[] listAttacks = gameObject.GetComponentsInChildren<AttackBase>();
        attacks = new List<AttackBase>();
        attacks.Clear();
        for (int i = 0; i < listAttacks.Length; i++)
            attacks.Add(listAttacks[i]);    
    }

    private AttackBase AttackToUse()
    {
        List<AttackBase> availableAttacks = new List<AttackBase>();

        foreach (AttackBase items in attacks)
        {
            if (items.CanExcuteAttack(attackTarget.position))
                availableAttacks.Add(items);
        }

        if (availableAttacks.Count > 0)
        {
            return availableAttacks[UnityEngine.Random.Range(0, availableAttacks.Count - 1)];
        }
        else
            return null;
    }

    void Attack()
    {
        AttackBase attack = AttackToUse();
        if ( ! AttackToUse())
            return;
        currentAttack = attack;
   
        StartCoroutine(WaitForAttack(currentAttack.attackDuration));

        if (!currentAttack.hasAni)
            currentAttack.ExcuteAttack(attackTarget);
        currentAttack.StartCooldown();
        //animator.SetTrigger(currentAttack.aniTrigger);
        //Debug.Log(currentAttack.aniTrigger);
    }

    public void AniTriggerAttack()
    {
        currentAttack.ExcuteAttack(attackTarget);
    }

    private void Update()
    {
        if(!attackTarget)
            return;

        if (isAttacking)
            return;

        Attack();
    }

    public virtual void SetTarget(Transform target)
    {
        attackTarget = target;
    }

    private IEnumerator WaitForAttack(float delay)
    {
        isAttacking = true;
        if(currentAttack.stopMovBeh)
            movBeh.SetCanMove(false);
        yield return new WaitForSeconds(delay);
        if (currentAttack.isHasEventFinishAttack)
        {
            currentAttack.ExcuteAttack(attackTarget);
        }
        if (currentAttack.stopMovBeh)
            movBeh.SetCanMove(true);

        isAttacking = false;
    }
}
