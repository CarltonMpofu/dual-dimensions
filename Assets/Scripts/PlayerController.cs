using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Collider2D feet;

    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider2D;
    Animator myAnimator;

    public bool isActive = true;

    Vector2 moveDirection;
    Vector2 rawInput;
    bool isJumping;

    float gravityScaleAtStart;


    const string platformLayer = "Platform";
    const string climbLayer = "Climbing";

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myAnimator = GetComponentInChildren<Animator>();
        gravityScaleAtStart = rb.gravityScale;
    }

    void FixedUpdate()
    {
        Walk();
        FlipSprite();
        ClimbLadder();

        //Make the player jump
        if (isJumping)
        {
            rb.velocity += new Vector2(0f, jumpForce);
            isJumping = false;
        }
    }

    private void Walk()
    {
        //Move the player
        rb.velocity = new Vector2(rawInput.x * moveSpeed, rb.velocity.y);

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1);
        }
    }

    void ClimbLadder()
   {
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask(climbLayer))) 
        {
            rb.gravityScale = gravityScaleAtStart;  
            myAnimator.SetBool("isClimbing", false);
            return; 
        }
        //Debug.Log("Do");
        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        // if(playerHasVerticalSpeed)
        // {
        //     myAnimator.SetBool("isClimbing", true);
        // }
        // else
        // {
        //      myAnimator.SetBool("isClimbing", false);
        // }
        
        rb.velocity = new Vector2(rb.velocity.x, rawInput.y * climbSpeed);
        rb.gravityScale = 0;
        //Debug.Log(rawInput.y * climbSpeed);
   }

    //Used by the input system 
    void OnMove(InputValue value)
    {
        if (!isActive) { return; }
        rawInput = value.Get<Vector2>();
    }

    //Used by the input system
    void OnJump(InputValue value)
    {
        if (!isActive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask(platformLayer))) { return; }

        isJumping = true;
    }
}
