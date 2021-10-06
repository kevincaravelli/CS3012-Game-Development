using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] float velocity = 5.0f;
    [SerializeField] Transform pathPrefab;

    public float getVelocity()
    {
        return velocity;
    }

    public Transform getFirstWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> getWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
