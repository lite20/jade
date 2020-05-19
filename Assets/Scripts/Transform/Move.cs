using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;

    private InputSys controls;
    
    private Vector2 dir;

    public void Awake()
    {
        controls = new InputSys();
        controls.Enable();
        controls.Player.Move.performed += ctx => OnMove(ctx);
        controls.Player.Move.canceled += ctx => OnMoveDone();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        // we are trusting that the magnitude is 1.0 or less
        dir = ctx.ReadValue<Vector2>();
    }

    public void OnMoveDone()
    {
        dir = Vector2.zero;
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(dir.x * speed, 0, dir.y * speed);
        Debug.Log(rb.velocity.magnitude);
    }
}
