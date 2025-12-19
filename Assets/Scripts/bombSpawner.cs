using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = true;

    void Start()
    {
        Debug.Log("ObstacleSpawner Started");
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                yield return StartCoroutine(SpawnWave(wave));
            }
        }
        while (looping);
    }

    IEnumerator SpawnWave(WaveConfig wave)
    {
        GameObject path = Instantiate(wave.GetPathPrefab());

        for (int i = 0; i < wave.GetNumberOfObstacles(); i++)
        {
            Instantiate(
                wave.GetObstaclePrefab(),
                path.transform.GetChild(0).position,
                Quaternion.identity,
                path.transform
            );

            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }
}


