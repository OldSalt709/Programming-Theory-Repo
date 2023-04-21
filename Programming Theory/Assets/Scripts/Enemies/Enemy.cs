using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject targetPlayer;
    private float speed = 2.0f;
    [SerializeField] private GameObject wreckedVersion;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (targetPlayer.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(wreckedVersion, transform.position, transform.rotation);
        }
    }
}
