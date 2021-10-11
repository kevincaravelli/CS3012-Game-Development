using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float velocity = 5.0f;
    [SerializeField] Transform pathPrefab;

    public int getEnemyPrefabCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject getEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

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
