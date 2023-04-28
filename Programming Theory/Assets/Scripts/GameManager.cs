using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool spawningActive;
    [SerializeField] private TextMeshProUGUI waveTimer_Text;

    private float countDown = 3.0f;
    private int enemyCount;

    [SerializeField] private GameObject[] enemyPrefab;
    private int waveNumber = 0;
    public bool isGameActive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        IncreaseLevel();
        SpawnTimer();

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
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab[spawnIndex], GenerateSpawnPosition(), enemyPrefab[spawnIndex].transform.rotation);
            }
        }    
    }

    void IncreaseLevel()
    {
        if (enemyCount == 0 && !spawningActive)
        {
            waveNumber++;
            countDown = 3.0f;
            spawningActive = true;
            Debug.Log($"The wave count is {waveNumber}");
        }
    }

    private void SpawnTimer()
    {
        if (countDown > 0)
        {
            waveTimer_Text.gameObject.SetActive(true);
            countDown -= Time.deltaTime;
        }

        double actualTimer = System.Math.Round(countDown, 0);
        waveTimer_Text.text = $"Next wave in: {actualTimer}";

        if (countDown < 0 && spawningActive)
        {
            Debug.Log("timer ding!");
            SpawnEnemyWave(waveNumber);
            waveTimer_Text.gameObject.SetActive(false);
            spawningActive = false;
        }
    }
}
