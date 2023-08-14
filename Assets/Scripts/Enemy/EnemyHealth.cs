using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private string id;
    
    [ContextMenu("Generate ID")]
    private void GenerateID()
    {
        id = System.Guid.NewGuid().ToString();
    }


    private void Start()
    {
        health = stats.maxHealth;
    }


    public override void TakeDamage(float damage, Transform hitPos = null)
    {
        health = health - damage;
        if (health <= 0)
        {
            Die();
        }
    }
}
