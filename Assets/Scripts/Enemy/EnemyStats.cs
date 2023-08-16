using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObject/EnemyStats", order = 1) ]

public class EnemyStats : ScriptableObject
{
    public float maxHealth;
    public float movementSpeed;
}
