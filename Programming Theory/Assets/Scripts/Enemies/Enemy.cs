using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRb;
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private GameObject wreckedVersion;
    [SerializeField] private Vector3 lookDirection;
    private GameObject[] randomTarget;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartComponents();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTurret();
        randomTarget = GameObject.FindGameObjectsWithTag("Player");
        int targetIndex = Random.Range(0, randomTarget.Length);
        {
            for (int i = 0; i < targetIndex; i++)
            {
                
            }
        }
    }

    private void StartComponents()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(wreckedVersion, transform.position, transform.rotation);
            gameManager.isGameActive = false;
        }
    }

    public virtual void MoveTowardsTurret()
    {
        lookDirection = (targetPlayer.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
