using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Rigidbody _rb;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();   
    }
    private void OnTriggerExit(Collider other) 
    {
        PlayerController controller = other.gameObject.GetComponentInParent<PlayerController>();
        
        if(controller)
        {
            Invoke("TileFall", 1f);
        }    
    }
    void TileFall()
    {
        _rb.isKinematic = false;
    }
}
