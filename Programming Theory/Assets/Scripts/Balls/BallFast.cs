using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFast : BallBase
{
    // POLYMORPHISM
    // Overrides speed and score value of parent class 
    private int twoApparently = 2;
    private int fastScore = 10;
    public override void AddScore()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue + fastScore);
    }
    public override void SubtractScore()
    {
        Destroy(gameObject);
        gameManager.UpdateScore((pointValue + fastScore) / -twoApparently);
    }

    public override void StartComponents()
    {
        base.StartComponents();
        speed *= twoApparently;
    }
    private void Start()
    {
        StartComponents();
    }
}
