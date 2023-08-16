using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] public ProjectileStats projectile;
    [SerializeField] private ParticleSystem hitEffect;  
    protected Action<ProjectileController> _killAction;

    public void InIt(Action<ProjectileController> killAction)
    {
        _killAction = killAction;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position , transform.forward, out hit, projectile.movSpeed * Time.fixedDeltaTime , projectile.hitMask)) 
        {
            if (hit.collider != null)
            {
                Debug.Log(hit);
                //_killAction(this);
                transform.position = hit.point;
                hitEffect.Play();
                DoDamage(hit);
            }
        }
        else 
        {
            transform.position += projectile.movSpeed * Time.fixedDeltaTime * transform.forward;
        }
    }

    protected void DoDamage(RaycastHit hit)
    {
        Health health;
        if (hit.transform.TryGetComponent<Health>(out health))
        {
            health.TakeDamage(1);
        }
    }
}
