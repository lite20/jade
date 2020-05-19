using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRotate : MonoBehaviour
{
    public float lerpFactor = 0.1f;

    private InputSys controls;

    private float targetAngle = 0.0f;

    public void Awake()
    {
        controls = new InputSys();
        controls.Enable();
        controls.Player.Move.performed += ctx => Rotate(ctx);
    }

    public void Update()
    {
        Vector3 rot = transform.eulerAngles;
        rot.y = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, lerpFactor);
        transform.eulerAngles = rot;
    }

    private void Rotate(InputAction.CallbackContext ctx)
    {
        targetAngle = -Vector2.SignedAngle(
            Vector2.up, ctx.ReadValue<Vector2>()
        );
    }
}
