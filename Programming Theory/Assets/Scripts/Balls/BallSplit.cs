using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSplit : BallBase
{
    public override void StartComponents()
    {
        if (MainManager.Instance != null)
        {
            speed *= MainManager.Instance.difficulty;
        }
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Destroy(gameObject, 5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartComponents();
    }

}
