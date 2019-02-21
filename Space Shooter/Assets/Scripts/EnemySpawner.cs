using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs = new List<WaveConfig>();
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
    
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            var newEnemy = Instantiate(waveConfig.EnemyPrefab,
                waveConfig.PathPrefab.GetComponentsInChildren<Transform>()[1].position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().WaveConfig = waveConfig;
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
