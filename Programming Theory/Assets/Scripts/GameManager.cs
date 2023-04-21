using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int enemyCount;
    [SerializeField] private GameObject[] enemyPrefab;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        IncreaseLevel();

    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomLocation = Random.Range(-9, 9);
        Vector3 randomPos = new Vector3 (randomLocation, 0.3f, 8);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int spawnIndex = Random.Range(0, enemyPrefab.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab[spawnIndex], GenerateSpawnPosition(), enemyPrefab[spawnIndex].transform.rotation);
        }
    }

    void IncreaseLevel()
    {
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
}
