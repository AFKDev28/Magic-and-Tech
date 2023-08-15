using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform player;

    [SerializeField] private float threshold;

    [SerializeField] private LayerMask mouseCollLayer;

    private void FixedUpdate()
    {
        Ray mouseRay = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, float.MaxValue, mouseCollLayer))
        {
            Vector3 targetDireciton =  - player.position + hitInfo.point;

            Vector3 direction =( -player.position + hitInfo.point).normalized;

            transform.position =  threshold * direction + player.position;


        }
    }


}
