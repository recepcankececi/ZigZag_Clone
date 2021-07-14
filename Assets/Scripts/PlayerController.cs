using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] Transform _playerRoot;
    [SerializeField] float _speed;
    [SerializeField] SpawnManager spawnManager;
    private int _direction = 0;
    private int _score = -1;
    private int _collisionCount;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    void Update()
    {
        switch (GameManager.instance.CurrentGameState)
            {
                case GameManager.GameState.Prepare:
                GameStart();
                    break;
                case GameManager.GameState.MainGame:
                PlayerMove();        
                CollisionCheck();               
                    break;
                case GameManager.GameState.FinishGame:   
                FinishMove();                     
                    break;
            }
    }
    void PlayerMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _direction++;
        }
        if(_direction % 2 == 0)
        {
            _playerRoot.Translate((Vector3.right + Vector3.forward) * Time.deltaTime * _speed);
        }
        if(_direction % 2 == 1)
        {
            _playerRoot.Translate((Vector3.left + Vector3.forward) * Time.deltaTime * _speed);
        }
    }
    void GameStart()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.instance.ToMain();
            UIManager.instance.GamePanel();
        }
    }
    void CollisionCheck()
    {
        if(_collisionCount == 0)
        {
            GameManager.instance.ToGameOver();
            _rb.isKinematic = false;
            UIManager.instance.RetryPanel();
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        _collisionCount++;
        _score++;
        UIManager.instance.ScoreUpdate(_score);
        spawnManager.SpawnTiles();
    }
    private void OnTriggerExit(Collider other) 
    {
        _collisionCount--;
    }
    void FinishMove()
    {
        if(_direction % 2 == 0)
        {
            _playerRoot.Translate((Vector3.right + Vector3.forward) * Time.deltaTime * _speed);
        }
        if(_direction % 2 == 1)
        {
            _playerRoot.Translate((Vector3.left + Vector3.forward) * Time.deltaTime * _speed);
        }
    }
}
