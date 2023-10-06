using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected Transform desPosition;

    [SerializeField] protected MovementBehavior behavior;

    [SerializeField] private Transform transform;

    private bool isStopped = false;

    private void FixedUpdate()
    {
        if (!isStopped)
        {
            behavior.Move(agent, transform.position, desPosition.position);
        }
    }

    public void SetCanMove(bool isStop)
    {
        isStopped = isStop;
        if (isStop)
        {
            agent.enabled = false;           
        }
        else
        {
            agent.enabled = true;
        }
    }
}
