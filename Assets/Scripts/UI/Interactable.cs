using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string label;

    public UnityEvent onInteract;

    public GameObject currentIndicator;

    private void Start()
    {
        if (onInteract == null) onInteract = new UnityEvent();
    }

    public void Interact()
    {
        onInteract.Invoke();
    }

    public string GetLabel()
    {
        return label;
    }
}
