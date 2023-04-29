using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshPro playerNameTag_Text;
    [SerializeField] private TextMeshProUGUI score_Text;
    [SerializeField] private GameObject[] ballPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        playerNameTag_Text.text = MainManager.Instance.playerName;
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int index = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        score_Text.text = $"Score: {score}";
    }
}
