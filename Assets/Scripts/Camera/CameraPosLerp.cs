using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosLerp : MonoBehaviour
{
    /// <summary>
    /// The object to coincide with
    /// </summary>
    public Transform target;

    /// <summary>
    /// The factor to lerp by
    /// </summary>
    public float lerpFactor;

    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position, target.position, lerpFactor * Time.deltaTime);
    }
}
