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
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
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

