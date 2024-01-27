using System;
using UnityEngine;
using UnityEngine.InputSystem;

using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed =5f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;

    CapsuleCollider2D myCapsualecollider2D;


    Animator myAnimator;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsualecollider2D = GetComponent<CapsuleCollider2D>();
       
    }

    void Update()
    {
        Run();
        FlipSprite();

    }
    
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
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
}   

