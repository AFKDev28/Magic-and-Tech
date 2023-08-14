using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected EnemyStats stats;
    protected float health;

    [SerializeField] protected GameObject deadEffect;

    protected bool isDead = false;


    public virtual void TakeDamage(float damage, Transform hitPos = null)
    {
        health = health - damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public float MaxHealth
    {
        get { return stats.maxHealth; }
    }

    public float CurentHealth
    {
        get { return health; }
    }

    protected virtual void Die()
    {
        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, Quaternion.identity);
        }
        gameObject.SetActive(false);
        isDead = true;
    }


}
