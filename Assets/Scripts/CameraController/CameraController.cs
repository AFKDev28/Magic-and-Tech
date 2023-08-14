using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            Vector3 mousePos = hitInfo.point;
            Vector3 targerPos = player.position + mousePos;

            targerPos.x = Mathf.Clamp(targerPos.x, -threshold + player.position.x, threshold + player.position.x);
            targerPos.z = Mathf.Clamp(targerPos.z, -threshold + player.position.z, threshold + player.position.z);

            this.transform.position = targerPos;
        }
    }
}
