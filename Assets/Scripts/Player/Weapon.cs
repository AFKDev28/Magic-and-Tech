using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/Weapon", order = 1)]

public class Weapon : ScriptableObject
{
    public ProjectileController projectilePrefab;
    public GameObject weaponPrefab;

    public float cooldownTime;

}
