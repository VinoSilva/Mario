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

    // [SerializeField]
    // private float fLerpSpeed = 0.0f;

    [Range(1.0f,1000.0f)]
    [SerializeField]
    private float fMaxSpeed = 1.0f;

    [Header("Jump Variables")]
    [SerializeField]
    [Range(0.0f, 10000.0f)]
    private float fJumpForce = 0.0f;


    [SerializeField]
    [Tooltip("Time in seconds before the player will drop or can't press jump")]
    [Range(0.0f,10.0f)]
    private float fTimeToFall = 0.5f;

    [SerializeField]
    [Range(0.0f,10.0f)]
    private float fGroundSphereRadius = 0.0f;

    [SerializeField]
    private LayerMask groundMask = 1;

    // Private variables to capture input data
    private Vector2 moveInput = Vector2.zero;

    // Private variables
    private bool isGrounded = false;

    private float fTargetSpeed = 0.0f;

    private float fCurrentSpeed = 0.0f;

    private float fFallTimer = 0.0f;

    [Header("Sound Clips")]

    [SerializeField]
    private AudioClip jumpAudioClip = null;

    private void Update() {
        UpdateFallTimer();
    }

    private void FixedUpdate()
    {
        Movement();

        CheckIsGrounded();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,0.0f);
        rb.AddForce(Vector2.up * fJumpForce, ForceMode2D.Impulse);
        SoundManager.Instance.PlayOneShot(jumpAudioClip);
    }

    private void Movement()
    {
        // fCurrentSpeed = Mathf.Lerp(fCurrentSpeed,fTargetSpeed,Time.deltaTime * fLerpSpeed);

        rb.velocity = new Vector2(fCurrentSpeed * Time.fixedDeltaTime,rb.velocity.y);

        if(moveInput.x == 0.0f && fTargetSpeed == 0.0f && Mathf.Abs(fCurrentSpeed - fTargetSpeed) <= 0.5f){
            animator.SetBool("isRun",false); 
        }
        else{
            animator.SetBool("isRun",true); 
        }
    }

    private void UpdateFallTimer(){
        if(isGrounded){
            fFallTimer = 0.0f;
        }
        else{
            fFallTimer += Time.deltaTime;
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        bool isHorizontal = moveInput.x != 0.0f;

        if(isHorizontal){
            spriteRenderer.flipX = moveInput.x < 0.0f;

            fTargetSpeed = moveInput.x * fMaxSpeed; 
        }
        else
        {
            fTargetSpeed = 0.0f;
        }

        fCurrentSpeed= fTargetSpeed;
    }

    private void OnJump(InputValue value)
    {
        if((isGrounded || fFallTimer <= fTimeToFall) && rb.velocity.y <= 0.0f){
            fFallTimer = fTimeToFall + Time.deltaTime;
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
