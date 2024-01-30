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
    [SerializeField] Vector2 deathKick = new Vector2 (10f, 10f);
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStar;

    bool isAlive =true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStar = myRigidbody.gravityScale;
       
    }

    void Update()
    {
        if(!isAlive) {return;}
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    
    void OnMove(InputValue value)
    {   
        if(!isAlive) {return;}
        moveInput=value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!isAlive) {return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if(value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f,jumpSpeed);
        }
    }
    void Run()
    {
        Vector2 PlayerVelocity = new Vector2(moveInput.x*runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity=PlayerVelocity;
        
        bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHorizontalSpeed);

    }
    void FlipSprite()
        {
            bool playerHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
            if(playerHorizontalSpeed)
            {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x),1f);
            }
               

        }
    void ClimbLadder()

        {
            if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
            {
                myRigidbody.gravityScale = gravityScaleAtStar;
                myAnimator.SetBool("isClimbing", false);
                return;
            }

            Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
            myRigidbody.velocity = climbVelocity;
            myRigidbody.gravityScale = 0f;

            bool playerVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y)>Mathf.Epsilon;
            myAnimator.SetBool("isClimbing", playerVerticalSpeed);
            
        }
    void Die()
    {
        if(myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
        }
    }
}   

