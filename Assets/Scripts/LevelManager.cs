using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] List<GameObject> levels;
    private int _index;
    private GameObject _currentLevel;
    public int Index { get => _index; }
    private void Start() 
    {
        SetInitialIndex();
        ManageLevel(_index);
    }
    private void SetInitialIndex()
    {
        _index = PlayerPrefs.GetInt("index", 0);
    }
    public void RestartLevel()
    {
        StartCoroutine(UIManager.instance.LevelLoadRoutine(_index));
    }
    public void LoadNextLevel()
    {
        _index++;
        PlayerPrefs.SetInt("index", _index);
        StartCoroutine(UIManager.instance.LevelLoadRoutine(_index));
    }
    public void ManageLevel(int index)
    {
        if(_currentLevel)
        {
            Destroy(_currentLevel);
        }
        if(index >= levels.Count)
        {
            return;
        }
        _currentLevel = Instantiate(levels[index], Vector3.zero, Quaternion.identity);
    }
    
}
