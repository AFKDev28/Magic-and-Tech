using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingMovement : MovementBehavior
{
    [SerializeField] private float minDistance;
    public override void Move(NavMeshAgent agent, Vector3 posi, Vector3 desPosi)
    {
        Vector3 pos = desPosi - (desPosi - posi).normalized * minDistance;
        agent.SetDestination(pos);
    }
}
