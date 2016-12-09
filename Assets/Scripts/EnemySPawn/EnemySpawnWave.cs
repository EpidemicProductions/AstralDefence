using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemySpawnWave : MonoBehaviour
{
    public GameObject Enemy = null;

    public int hazardCount = 3;
    public float spawnWait = 0.5f;
    public float startWait = 1;
    public float waveWait = 4;
    public Transform[] spawnPoints;

    public int waveCount = 1;
    public Text WaveText;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        WaveText.text = "";
    }

    void Update()
    {
        WaveText.text = ""+ waveCount;
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            // Only pick a new spawn point once per wave
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < hazardCount; i++)
            {
                // here would pick a new spawn point for each new enemy
                Instantiate(Enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            hazardCount += 5;
            waveCount += 1;
            print(waveCount);

        }
    }
}
