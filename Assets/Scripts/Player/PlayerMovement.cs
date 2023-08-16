using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Header("---------- Main Controller ----------")] 
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform pointToLook;

    [Header("---------- Movement ----------")]
    //[SerializeField] private PlayerInput playerInput;

    [SerializeField] private float movementSpeed;
    private Vector2 velocity;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //playerInput = new PlayerInput();
        //playerInput.PlayerController.Move.performed += ctx => velocity =
        //                              ctx.ReadValue<Vector2>();
        //playerInput.PlayerController.Move.canceled += ctx => velocity = Vector2.zero;

        //playerInput.PlayerController.Attack.performed += ExcuteAttack;
    }


    public void ReadMovemntValue(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x * movementSpeed, rb.velocity.y, velocity.y * movementSpeed);
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        transform.LookAt(new Vector3(pointToLook.position.x, transform.position.y, pointToLook.position.z));
    }
}
