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
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform pointToLook;

    [Header("----------InputSystem----------")]
    private PlayerInput playerInput;

    [SerializeField] private float movementSpeed;
    private Vector2 velocity;


    [Header("----------Attack----------")]

    [SerializeField] private float attackcoldown;
    [SerializeField] private IWeapon weapon;

   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.PlayerController.Move.performed += ctx => velocity =
                                      ctx.ReadValue<Vector2>();
        playerInput.PlayerController.Move.canceled += ctx => velocity = Vector2.zero;

        playerInput.PlayerController.Attack.performed += ExcuteAttack;
            }


    private void ExcuteAttack(InputAction.CallbackContext context)
    {
        Debug.Log("attack");
        weapon.ExcuteAttack();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(velocity.x * movementSpeed, rb.velocity.y, velocity.y * movementSpeed);
        LookAtMouse();
    }

    private void OnEnable()
    {
        playerInput.PlayerController.Enable();

    }
    private void OnDisable()
    {
        playerInput.PlayerController.Disable();
    }

    private void LookAtMouse()
    {
        weaponHolder.LookAt(new Vector3(pointToLook.position.x, transform.position.y, pointToLook.position.z));

    }


}
