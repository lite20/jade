using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityToAnim : MonoBehaviour
{
    public string paramName;

    public Animator anim;

    public Rigidbody rb;

    public void FixedUpdate()
    {
        anim.SetFloat(paramName, rb.velocity.magnitude);
    }
}
