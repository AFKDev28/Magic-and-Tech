using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]  protected HealthStats stats;
    protected int health;

    [SerializeField] protected GameObject deadEffect;

    private void Start()
    {
        health = stats.maxHealth;
    }
    public virtual void TakeDamage(int damage)
    {
        health = health - damage;
        Debug.Log(health);
        if(health <= 0)
        {
            Die();
        }
    }

    public int MaxHealth
    {
        get { return stats.maxHealth; }
    }

    public int CurentHealth
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
    }


}
