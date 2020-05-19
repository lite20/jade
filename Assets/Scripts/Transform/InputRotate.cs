using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRotate : MonoBehaviour
{
    private InputSys controls;

    // TODO: smooth with lerping
    public void Awake()
    {
        controls = new InputSys();
        controls.Enable();
        controls.Player.Move.performed += ctx => Rotate(ctx);
    }

    private void Rotate(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        float angle = -Vector2.SignedAngle(Vector2.up, dir);
        Vector3 rot = transform.eulerAngles;
        rot.y = angle;
        transform.eulerAngles = rot;
    }
}
