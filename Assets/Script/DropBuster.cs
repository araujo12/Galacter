using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBuster : MonoBehaviour
{
    public float rangMin, rangMax, spawnHeight, spawnDelay, spawnNextime, spawnRate;
    public GameObject busterPrefab;
    
    void Start()
    {
        spawnNextime = Time.time + spawnDelay;
        
    }

    // Update is called once per frame
    void Update()
    {
        IntervalSpawnBuster();
        
    }

    public void SpawnBuster()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(rangMin, rangMax), spawnHeight, 0f);
        GameObject buster = Instantiate(busterPrefab, spawnPosition, Quaternion.identity);
    }

    public void IntervalSpawnBuster()
    {
        if (Time.time >= spawnNextime)
        {
            SpawnBuster();
            spawnNextime = Time.time + spawnRate;
        }
    }


}
