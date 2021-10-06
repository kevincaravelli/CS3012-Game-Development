using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float velocity = 5.0f;
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Transform>();
        foreach(Transform child in path)
        {
            waypoints.Add(child);
        }

        // Debug.Log(waypoints.Count);
        // move the enemy object to the very first waypoint
        transform.position = waypoints[currentWaypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        followPath();
    }

    void followPath()
    {
        // As long as the current waypoint index is valid, keep moving
        if (currentWaypointIndex < waypoints.Count)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                waypoints[currentWaypointIndex].position,
                velocity * Time.deltaTime);

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
