using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVehicle : MonoBehaviour
{
    /// <summary>
    /// Vehicle to track
    /// </summary>
    public Transform vehicle;

    /// <summary>
    /// Factor to lerp by
    /// </summary>
    public float lerpFactor;

    /// <summary>
    /// Offset to have from the vehicle
    /// </summary>
    public Vector3 offset;

    private void Update()
    {
        // compute target position
        Vector3 target = (vehicle.rotation * offset) + vehicle.position;
        transform.position = Vector3.Lerp(
            transform.position, target, lerpFactor);

        // force camera to be set offset from vehicle
        // Vector3 diff = transform.position - vehicle.position;
        // transform.position = vehicle.position + (diff.normalized * offset.magnitude);

        // look towards vehicle
        transform.LookAt(vehicle.position);
    }
}
