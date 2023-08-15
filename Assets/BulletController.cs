using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float movSpeed;
    public static float raycastLength = 0.2f;
    [SerializeField] LayerMask raycastMask;

    protected Action<BulletController> _killAction;


    public void InIt(Action<BulletController> killAction)
    {
        _killAction = killAction;
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(transform.position, transform.position + transform.right * raycastLength);

    //}
    private void Update()
    {
        transform.position += movSpeed * Time.deltaTime * transform.forward;
    }

}
