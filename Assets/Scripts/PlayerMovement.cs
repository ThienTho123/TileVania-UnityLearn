using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed =5f;
    [SerializeField] float climbSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCapsualecollider2D;
    float gravityScaleAtStar;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsualecollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStar = myrigidbody.gravityScale;
       
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    
    void OnMove(InputValue value)
    {
        moveInput=value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!myCapsualecollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if(value.isPressed)
        {
            myrigidbody.velocity += new Vector2(0f,jumpSpeed);
        }
    }
    void Run()
    {
        Vector2 PlayerVelocity = new Vector2(moveInput.x*runSpeed, myrigidbody.velocity.y);
        myrigidbody.velocity=PlayerVelocity;
        
        bool playerHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x)>Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHorizontalSpeed);

    }
    void FlipSprite()
        {
            bool playerHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x)>Mathf.Epsilon;
            if(playerHorizontalSpeed)
            {
            transform.localScale = new Vector2 (Mathf.Sign(myrigidbody.velocity.x),1f);
            }
               

        }
    void ClimbLadder()

        {
            if(!myCapsualecollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
            {
                myrigidbody.gravityScale = gravityScaleAtStar;
                myAnimator.SetBool("isClimbing", false);
                return;
            }

            Vector2 climbVelocity = new Vector2(myrigidbody.velocity.x, moveInput.y * climbSpeed);
            myrigidbody.velocity = climbVelocity;
            myrigidbody.gravityScale = 0f;

            bool playerVerticalSpeed = Mathf.Abs(myrigidbody.velocity.y)>Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerVerticalSpeed);
            
        }

}   

