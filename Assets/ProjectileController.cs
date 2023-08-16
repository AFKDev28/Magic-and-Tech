using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] public ProjectileStats projectile;

    protected Action<ProjectileController> _killAction;

    public void InIt(Action<ProjectileController> killAction)
    {
        _killAction = killAction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * projectile.raycastLength);

    }
    private void Update()
    {
        RaycastHit hit;
        if( Physics.Raycast(transform.position - transform.forward * projectile.raycastLength, transform.forward, out hit,projectile.raycastLength, projectile.hitMask ));
        {
            if( hit.collider != null )
            {
                Debug.Log(hit);
                _killAction(this);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += projectile.movSpeed * Time.deltaTime * transform.forward;
    }
}
