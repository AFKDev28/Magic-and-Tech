using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingMovement : MovementBehavior
{
    public override void Move(NavMeshAgent agent, Vector3 posi, Vector3 desPosi)
    {
        agent.SetDestination(desPosi);
    }
}
