using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthStats", menuName = "ScriptableObject/HealthStats", order = 1) ]

public class HealthStats : ScriptableObject
{
    public int maxHealth;
    public float movementSpeed;
}
