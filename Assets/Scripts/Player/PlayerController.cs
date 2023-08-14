using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [Header("Main Controller")] 
    [SerializeField] private Rigidbody rb;


    [Header("----------InputSystem----------")]
    private PlayerInput playerInput;

    [SerializeField] private float movementSpeed;
    private Vector2 velocity;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.PlayerController.Move.performed += ctx => velocity =
                                      ctx.ReadValue<Vector2>();
        playerInput.PlayerController.Move.canceled += ctx => velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x * movementSpeed, rb.velocity.y, velocity.y * movementSpeed);
    }

    private void OnEnable()
    {
        playerInput.PlayerController.Enable();

    }
    private void OnDisable()
    {
        playerInput.PlayerController.Disable();
    }

}
