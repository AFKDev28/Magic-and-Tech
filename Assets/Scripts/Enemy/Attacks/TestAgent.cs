using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private void OnEnable()
    {
        agent.enabled = false;
    }

    private void OnDisable()
    {
        agent.enabled = true ;
    }
}
