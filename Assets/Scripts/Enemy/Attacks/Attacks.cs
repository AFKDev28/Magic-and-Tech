using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private List<AttackBase> attacks;

    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovement movBeh;

    [SerializeField] private Transform attackTarget;

    private AttackBase currentAttack;
    private bool isAttacking;

    private void Start()
    {
        GetListAttacks();
        isAttacking = false;
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
            return availableAttacks[UnityEngine.Random.Range(0, availableAttacks.Count)];
        }
        else
            return null;
    }

    void Attack()
    {
        // Get random available attacks
        currentAttack = AttackToUse();

        if (!currentAttack)
            return;
        else
            StartCoroutine(DoTheAttack());
    }
  
    private void FixedUpdate()
    {
        if (!attackTarget)
            return;

        if (isAttacking)
        {
            currentAttack.OnExecutingAttack(attackTarget);
        }
        else
            Attack();
    }

    public virtual void SetTarget(Transform target)
    {
        attackTarget = target;
    }

    private IEnumerator DoTheAttack()
    {
        //Begin AttackTrigger
        isAttacking = true;

        if(currentAttack.stopMovBeh)
            movBeh.SetCanMove(true);
        currentAttack.StartAttack(attackTarget);

        if (currentAttack.hasAni)
            animator.SetTrigger(currentAttack.aniTrigger);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(currentAttack.attackDuration);
        Debug.Log(Time.time);

        //End AttackTrigger
        currentAttack.EndAttack(attackTarget);
        if (currentAttack.stopMovBeh)
            movBeh.SetCanMove(false);
        isAttacking = false;
    }

    public void AniTriggerAttack()
    {
        currentAttack.ChangeAttackState();
    }
}
