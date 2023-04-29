using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    // INHERITANCE
    // All Ball are child classes of BallBase
    public int pointValue = 10;
    public GameManager gameManager;
    private float xSpawnRange = 3f;
    private float ySpawnPosition = 4f;

    /// <summary>
    /// ENCAPSULATION example 
    /// replaced course code example (ref00) with Mathf.Max so it chooses the higher of the two numbers. 
    /// Basically a minimum speed.
    /// </summary>
    private float m_speed = 1f;
    public float speed
    {
        get { return m_speed; }
        set 
        {
            m_speed = Mathf.Max(1.0f, value); 
            /* (ref00)
            if (value < 0.0f)
            {
                Debug.LogError("I'm afraid I can't let you do that Dave...");
            }
            else
            {
                m_speed = value;
            }
            */
        }
    }

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

    //ABSTRACTION?? I think this is an example..
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
        if (MainManager.Instance != null)
        {
            speed *= MainManager.Instance.difficulty;
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = RandomSpawnPosition();
        Destroy(gameObject, 5f);
    }
}
