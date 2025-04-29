using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public GameManager gameManager;

    private int waveIndex = 0;

    void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }


        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
            return;
        }


        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        waveIndex++;

        foreach (var enemyType in wave.typesOfEnemys)
        {
            for (int i = 0; i < enemyType.count; i++)
            {
                SpawnEnemy(enemyType.unit);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    public void EnemyDied()
    {
        EnemiesAlive--;
        EnemiesAlive = Mathf.Clamp(EnemiesAlive, 0, int.MaxValue);
    }
}
