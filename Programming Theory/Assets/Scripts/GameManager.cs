using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // variables for gameplay
    private float countdown = 30.0f;
    public bool isGameActive = true;
    private int score = 0;

    // variables for adding User Interface objects
    [SerializeField] private TextMeshProUGUI score_Text;
    [SerializeField] private TextMeshPro playerNameTag_Text;
    [SerializeField] private TextMeshProUGUI gameTimer_Text;
    [SerializeField] private GameObject titleScreen_Button;

    // array for spawning balls to drop
    [SerializeField] private GameObject[] ballPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance != null) 
        {
            playerNameTag_Text.text = MainManager.Instance.playerName;
        }
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer();
    }

    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            int index = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        if (isGameActive) 
        {
            score += scoreToAdd;
            score_Text.text = $"Score: {score}";
        }
    }

    void GameTimer()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }

        double actualTimer = System.Math.Round(countdown, 1);
        gameTimer_Text.text = actualTimer.ToString();

        if (countdown < 0)
        {
            titleScreen_Button.gameObject.SetActive(true);
            Debug.Log("Ding fries are done!");
            isGameActive = false;
        }
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
