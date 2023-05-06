using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPrefabs;
    //[SerializeField] Transform startPoint;
    [SerializeField] float timeSpawn;
    
    float spawnTimer;

    

    private void Start()
    {
        
    }

    private void Update()
    {
        
        SpawnEnemy();
        
    }

    void SpawnEnemy()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= timeSpawn)
        {
            Instantiate(EnemyPrefabs[Random.Range(0, 2)], GameManager.Instance.mapPoints[0].transform.position , transform.rotation);
            
            spawnTimer = 0;
            
        }
    } 

}
