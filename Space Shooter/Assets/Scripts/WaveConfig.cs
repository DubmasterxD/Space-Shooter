using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab = null;
    [SerializeField] GameObject pathPrefab = null;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.05f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject EnemyPrefab
    {
        get { return enemyPrefab; }
    }

    public GameObject PathPrefab
    {
        get { return pathPrefab; }
    }

    public float TimeBetweenSpawns
    {
        get { return timeBetweenSpawns; }
    }

    public float SpawnRandomFactor
    {
        get { return spawnRandomFactor; }
    }

    public int NumberOfEnemies
    {
        get { return numberOfEnemies; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
}
