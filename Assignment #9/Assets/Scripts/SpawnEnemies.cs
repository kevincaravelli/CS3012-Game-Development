using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab;
    private float spawnTime, time;
    private float minTime = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        setRandomTime();
        time = minTime;
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            spawnEnemy();
            setRandomTime();
        }
    }

    void spawnEnemy()
    {
        time = minTime;

        Instantiate((enemyPrefab[Random.Range(0, 2)]), 
            new Vector3(-7.0f, Random.Range(0.5f, 8.5f), 0), Quaternion.identity);
    }

    private void setRandomTime()
    {
        spawnTime = Random.Range(minTime, 10);
    }
}
