using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public float spawnRate,spawnDelay,spawnHeight, nextSpawnTime,rangMin,rangMax;


    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;

    }
    
    void Update()
    {
        IntervalSpawn();
    }

    public void IntervalSpawn()
    {
        if (Time.time >= nextSpawnTime)
        {            
            SpawnEnemys();
            nextSpawnTime = Time.time + spawnRate;
        }
    }


    public void SpawnEnemys()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(rangMin, rangMax), spawnHeight, 0f);       
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        
    }


}
