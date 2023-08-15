using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingMovement : MonoBehaviour
{
   [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform desPosition;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(desPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
