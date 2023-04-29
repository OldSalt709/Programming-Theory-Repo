using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public int pointValue = 10;
    public GameManager gameManager;
    private float xSpawnRange = 3f;
    private float ySpawnPosition = 4f;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartComponents();
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddScore();
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            SubtractScore();
        }
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPosition);
    }

    public virtual void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public virtual void AddScore()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
    }

    public virtual void SubtractScore()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue / -2);
    }

    public virtual void StartComponents()
    {
        speed *= MainManager.Instance.difficulty;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = RandomSpawnPosition();
        Destroy(gameObject, 5f);
    }
}
