using UnityEngine;
using UnityEngine.AI;

public abstract class MovementBehavior : MonoBehaviour
{
    public abstract void Move(NavMeshAgent agent, Vector3 posi, Vector3 desPosi);
}
