using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeMovement : MovementBehavior
{
    [SerializeField] private float maxDis = 0, minDis = 0;

    public override void Move(NavMeshAgent agent, Vector3 posi, Vector3 desPosi)
    { 
        Vector3 dir  = (posi - desPosi);
        if(dir.magnitude > maxDis )
        {
            agent.SetDestination(desPosi + dir.normalized * maxDis);
        }
        else if(dir.magnitude < minDis )
        {
            agent.SetDestination(desPosi + dir * minDis);
        }
    }
}
