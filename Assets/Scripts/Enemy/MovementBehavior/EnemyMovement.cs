using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected Transform desPosition;

    [SerializeField] protected MovementBehavior behavior;

    [SerializeField] private Transform transform;

    private bool canMove = true;
    private void FixedUpdate()
    {
        if (canMove)
        {
            behavior.Move(agent, transform.position, desPosition.position);
        }
    }

    public void SetCanMove(bool canMove) => this.canMove = canMove;

}
