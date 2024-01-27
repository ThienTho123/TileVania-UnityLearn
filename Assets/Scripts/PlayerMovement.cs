using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
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
        Debug.Log(moveInput);
    }
    
    void Run()
    {
        myrigidbody.velocity=moveInput;
    }
}   

