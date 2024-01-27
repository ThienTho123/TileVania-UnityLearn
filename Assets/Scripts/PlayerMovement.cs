using System;
using UnityEngine;
using UnityEngine.InputSystem;

using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runspeed = 5f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;

    Animator myAnimator;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
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
    
    void Run()
    {
        Vector2 PlayerVelocity = new Vector2(moveInput.x*runspeed, myrigidbody.velocity.y);
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
            if(myAnimator)
            {

            }        

        }
}   

