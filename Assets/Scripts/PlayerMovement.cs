using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
}   

