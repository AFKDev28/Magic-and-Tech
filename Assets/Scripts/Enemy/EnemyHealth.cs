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
}
