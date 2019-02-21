using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig = null;
    GameObject path = null;
    int waypointIndex = 0;
    List<Transform> waypoints = new List<Transform>();

    public WaveConfig WaveConfig
    {
        set
        {
            waveConfig = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AddWaypointsToList();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void AddWaypointsToList()
    {
        path = waveConfig.PathPrefab;
        foreach (Transform waypoint in path.GetComponentsInChildren<Transform>())
        {
            waypoints.Add(waypoint);
        }
        waypoints.RemoveAt(0);
    }

    private void Move()
    {
        if (waypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
