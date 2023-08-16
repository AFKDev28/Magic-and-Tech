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

    [Header("---------- Dash ----------")]

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCD;
    [SerializeField] private LayerMask hitMask;

    private Vector2 dashVelocity;
    private bool isDashing = false;
    private bool canDash = true;


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
            velocity = context.ReadValue<Vector2>() * movementSpeed;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (canDash)
        {
            dashVelocity = dashSpeed * (velocity != Vector2.zero ? velocity.normalized 
                : new Vector2 (transform.forward.x , transform.forward.z).normalized);
            StartCoroutine(DashCooldown());
        }
    }


    private IEnumerator DashCooldown()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.velocity = new Vector3(dashVelocity.x, rb.velocity.y, dashVelocity.y);
            RaycastHit hit;
            if (Physics.Raycast(transform.position  , rb.velocity.normalized, out hit, rb.velocity.magnitude * Time.fixedDeltaTime , hitMask)) ;
            {
                if(hit.collider)
                {
                    transform.position = hit.point;
                    dashVelocity = Vector2.zero;
                }
            }

        }
        else
        {
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);
        }
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        transform.LookAt(new Vector3(pointToLook.position.x, transform.position.y, pointToLook.position.z));
    }
}
