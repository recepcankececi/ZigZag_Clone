using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private Transform _level;
    private float spawnPosX;
    private float spawnPosZ = -2.12132f;
    public float SpawnPosX { get => spawnPosX;}
    public float SpawnPosZ { get => spawnPosZ;}
    private void Start() 
    {
        _level = FindObjectOfType<SpawnManager>().transform;
        GenerateStartTiles();
    }
    private void GenerateStartTiles()
    {
        for(int i = 0; i < 30; i++)
        {
            SpawnTiles();
        }
    }
    public void SpawnTiles()
    {
        GetPositionXandZ();
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        GameObject obj = ObjectPooler.instance.SpawnFromPool("tile", spawnPos, Quaternion.identity);
        if(obj)
        {
            obj.transform.SetParent(_level);
        }      
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        int temp = Random.Range(0, 5);
        if(temp == 0)
        {
            GameObject colObj = ObjectPooler.instance.SpawnFromPool("diamond", spawnPos, Quaternion.identity);
            if(colObj)
            {
                colObj.transform.SetParent(_level);
            }
        }
    }
    private void GetPositionXandZ()
    {
        int temp = Random.Range(0, 2);
        if(temp == 0)
        {
            if(spawnPosX >= 8f)
            {
                spawnPosX -= 2.12132f;
            }
            else
            {
                spawnPosX += 2.12132f;
            }           
        }
        else
        {
            if(spawnPosX <= -8f)
            {
                spawnPosX += 2.12132f;
            }
            else
            {
                spawnPosX -= 2.12132f;
            }  
        }
        spawnPosZ += 2.12132f;
    }
}