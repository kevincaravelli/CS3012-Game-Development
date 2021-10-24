using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waveConfig = enemySpawner.getWaveConfig();
        waypoints = waveConfig.getWaypoints ();
        /*
        foreach (Transform child in path)
        {
            waypoints.Add(child);
        }
        */
        // Debug.Log(waypoints.Count);
        // move the enemy object to the very first way point
        transform.position = waypoints[currentWaypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        // as long as the current waypoint index is valid, keep moving
        if (currentWaypointIndex < waypoints.Count)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                waypoints[currentWaypointIndex].position,
                waveConfig.getVelocity() * Time.deltaTime
                );
            // if we reached the current destination, move to the next one
            if (transform.position == waypoints[currentWaypointIndex].position)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // if it reached the last waypoint, destroy the game object
            Destroy(gameObject);
        }
    }
}
