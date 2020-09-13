using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody rb;

    private InputSys controls;

    private Vector2 dir;

    public void Awake()
    {
        controls = new InputSys();
        controls.Enable();
        controls.Player.Move.started   += ctx => Move(ctx);
        controls.Player.Move.started   += ctx => Move(ctx);
        controls.Player.Move.performed += ctx => Move(ctx);
        controls.Player.Move.canceled  += ctx => MoveEnd();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // we are trusting that the magnitude is 1.0 or less
    private void Move(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    private void MoveEnd()
    {
        dir = Vector2.zero;
    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector3(dir.x * speed, 0, dir.y * speed);
    }
}
