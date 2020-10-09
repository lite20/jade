using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public GameObject labelPrefab;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CreateLabel(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        DestroyLabel(other.gameObject);
    }
    
    private void CreateLabel(GameObject obj)
    {
        Interactable inter = obj.GetComponent<Interactable>();
        string labelText = inter.GetLabel();

        // TODO: instantiate label prefab
        Debug.Log("[E] " + labelText);

        // save the thing that's currently interactable in a variable
    }

    private void DestroyLabel(GameObject obj)
    {
        // TODO: remove label
        Interactable inter = obj.GetComponent<Interactable>();
        
    }
}
