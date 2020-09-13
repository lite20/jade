using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flight : MonoBehaviour
{
    public float thrust = 10.0f;
    public float maxVelocity = 50.0f;
    public float airBreakFactor = 0.1f;
    public float turnFactor = 1.0f;
    public float turnAngle = 20.0f;
    private float angle = 0.0f;

    public Transform vehicle;

    private InputSys controls;

    private Vector2 dir;

    private Rigidbody rb;

    private bool turning = false;
    private bool accelerating = false;
    private bool breaking = false;

    private void Awake()
    {
        controls = new InputSys();
        controls.Enable();

        controls.Player.Move.started   += ctx => Move(ctx);
        controls.Player.Move.performed += ctx => Move(ctx);
        controls.Player.Move.canceled  += ctx => MoveEnd();

        controls.Player.Accelerate.started   += ctx => Accel(ctx);
        controls.Player.Accelerate.performed += ctx => Accel(ctx);
        controls.Player.Accelerate.canceled  += ctx => AccelEnd();
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        turning = true;
    }

    private void MoveEnd()
    {
        dir = Vector2.zero;
        turning = false;
    }

    private void Accel(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();
        if (val > 0)
        {
            accelerating = true;
            breaking = false;
        }
        else
        {
            breaking = true;
            accelerating = false;
        }
    }

    private void AccelEnd()
    {
        breaking = false;
        accelerating = false;
    }
    
    private void Update()
    {
        angle = Mathf.Lerp(angle, -dir.x * turnAngle, turnFactor);
        vehicle.localRotation = Quaternion.Euler(
            0.0f, 0.0f, angle);
    }

    private void FixedUpdate()
    {
        // accelerate
        if (accelerating)
        {
            // cap velocity
            if (rb.velocity.magnitude < maxVelocity)
                rb.AddForce(transform.forward * thrust);
        }

        // decelerate
        else if (breaking)
            rb.velocity = Vector3.Lerp(
                rb.velocity, Vector3.zero, airBreakFactor);

        // turn
        if (turning)
        {
            // pitch
            transform.Rotate(-dir.y, 0.0f, 0.0f, Space.Self);

            // yaw
            transform.Rotate(0.0f, dir.x, 0.0f, Space.World);

            // adjust velocity
            rb.velocity = transform.rotation * new Vector3(
                0.0f, 0.0f, rb.velocity.magnitude);
        }
        
        // TODO: psuedo-gravity
    }
}
