using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    /// <summary>
    /// The object to look at
    /// </summary>
    public Transform target;

    /// <summary>
    /// The factor to lerp by
    ///
    public float lerpFactor;

    private void Update()
    {
        Quaternion rot = Quaternion.LookRotation(
            target.position - transform.position);

        transform.rotation = Quaternion.Lerp(
            transform.rotation, rot, lerpFactor);
    }
}
    