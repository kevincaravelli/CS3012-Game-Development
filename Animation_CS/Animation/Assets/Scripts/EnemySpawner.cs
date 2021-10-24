using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    private int currentEnemy = 0;
    IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnEnemy(3);
        SpawnEnemies();   
    }

    public WaveConfig getWaveConfig()
    {
        return waveConfig;
    }


    void SpawnEnemies()
    {
        /*
        while (currentEnemy < waveConfig.getEnemyPrefabCount())
        {
            Instantiate(
                waveConfig.getEnemyPrefab(currentEnemy),
                waveConfig.getFirstWaypoint().position,
                Quaternion.identity
                );
            currentEnemy++;
        }
        */
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnEnemy(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (currentEnemy < waveConfig.getEnemyPrefabCount())
        {
            Instantiate(
                waveConfig.getEnemyPrefab(currentEnemy),
                waveConfig.getFirstWaypoint().position,
                Quaternion.identity
            );
            currentEnemy++;
            StartCoroutine(SpawnEnemy(3));
        }
    }
}
