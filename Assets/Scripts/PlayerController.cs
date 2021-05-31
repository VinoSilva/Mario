using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component references")]
    [SerializeField]
    private Rigidbody2D rb = null;

    [SerializeField]
    private BoxCollider2D boxCollider2D = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Animator animator = null;

    [Header("Movement Variables")]
    [Range(1.0f, 1000.0f)]
    [SerializeField]
    private float fMoveSpeed = 1.0f;

    [Header("Jump Variables")]
    [SerializeField]
    [Range(0.0f, 10000.0f)]
    private float fJumpForce = 0.0f;

    [SerializeField]
    [Range(0.10f,10.0f)]
    private float fGroundSphereRadius = 0.0f;

    [SerializeField]
    private LayerMask groundMask = 1;

    // Private variables to capture input data
    private Vector2 moveInput = Vector2.zero;

    // Private variables
    private bool isGrounded = false;

    [SerializeField]
    private AudioClip jumpAudioClip = null;

    private void FixedUpdate()
    {
        Movement();

        CheckIsGrounded();
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * fJumpForce, ForceMode2D.Impulse);
        SoundManager.Instance.PlayOneShot(jumpAudioClip);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveInput.normalized.x * fMoveSpeed * Time.fixedDeltaTime,rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        bool isHorizontal = moveInput.x != 0.0f;

        if(isHorizontal){
            spriteRenderer.flipX = moveInput.x < 0.0f;
        }

        animator.SetBool("isRun",isHorizontal); 
    }

    private void OnJump(InputValue value)
    {
        if(isGrounded){
            Jump();
        }
    }

    private void CheckIsGrounded(){

        Vector3 checkPosition = Vector3.down * boxCollider2D.size.y/2 + transform.position;

        DebugExtension.DebugWireSphere(checkPosition,Color.red,fGroundSphereRadius,Time.deltaTime);

        Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)checkPosition,fGroundSphereRadius,groundMask);

        if(rb.velocity.y <= 0.0f){
            if(colliders.Length > 0)
            {
                isGrounded = true;
            }
            else{
                isGrounded = false;
            }
        }
        else{
            isGrounded = false;
        }

        animator.SetBool("isJump",!isGrounded);
    }
}
