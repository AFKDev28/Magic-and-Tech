using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ProjectilesStats", menuName = "ScriptableObject/ProjectilesStats", order = 1)]


public class ProjectileStats : ScriptableObject
{
    public float movSpeed;
    public float raycastLength;
    public LayerMask hitMask;
}
