using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    ParticleSystem _colParticle;
    private void Start() 
    {
        _colParticle = FindObjectOfType<ParticleSystem>();
    }
    private void Update() 
    {
        transform.Rotate(0, 1, 0);    
    }
    private void OnTriggerEnter(Collider other) 
    {
        _colParticle.transform.position = transform.position + Vector3.up;
        _colParticle.Play();
        Destroy(gameObject);    
    }
}
