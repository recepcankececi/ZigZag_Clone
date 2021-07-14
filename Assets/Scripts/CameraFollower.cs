using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform _playerRoot;
    [SerializeField] float _offset = 70f;
    private void Start() 
    {
        cam = Camera.main;    
    }
    private void Update() 
    {
        switch (GameManager.instance.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                
                    break;
                case GameManager.GameState.MainGame:
                CamFollow();               
                    break;
                case GameManager.GameState.FinishGame:   
                                     
                    break;
            }
    }
    void CamFollow()
    {
        var camPosZ = _playerRoot.position.z - _offset;
        cam.transform.position =  new Vector3(0, cam.transform.position.y, camPosZ);
    }
}
