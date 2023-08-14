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
    private PlayerInputActions playerInputActions;

    [SerializeField] private float movementSpeed;
    private Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerController.Move.performed += ctx => velocity =
                                      ctx.ReadValue<Vector2>();
        playerInputActions.PlayerController.Move.canceled += ctx => velocity = Vector2.zero;
    }

    private void Update()
    {
        //velocity = playerInputActions.PlayerController.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x * movementSpeed, rb.velocity.y, velocity.y * movementSpeed);
    }

    private void OnEnable()
    {
        EnableInput();

    }
    private void OnDisable()
    {
        DisableInput();
    }

    private void DisableInput()
    {
        playerInputActions.PlayerController.Disable();
    }
    private void EnableInput()
    {
        playerInputActions.PlayerController.Enable();
    }

}
