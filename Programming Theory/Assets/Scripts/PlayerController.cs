using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private float speed = 5;
    private float xBoundry = 3;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MovePlayer();
        BoundPlayer();
    }

    void MovePlayer()
    {
        if (gameManager != null)
        {
            if (gameManager.isGameActive)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }
        }
    }

    void BoundPlayer()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBoundry, xBoundry), transform.position.y, transform.position.z);
    }
}
