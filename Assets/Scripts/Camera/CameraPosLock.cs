using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosLock : MonoBehaviour
{
    /// <summary>
    /// The object to coincide with
    /// </summary>
    public Transform target;

    private void Update()
    {
        transform.position = target.position;
    }
}
