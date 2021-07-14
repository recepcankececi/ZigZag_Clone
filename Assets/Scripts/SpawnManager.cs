using System;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private float spawnPosX;
    private float spawnPosZ;
    private void Start() 
    {
        spawnPosZ = -2.12132f;
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
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.isKinematic = true;
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