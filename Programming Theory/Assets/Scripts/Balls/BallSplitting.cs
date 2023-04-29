using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSplitting : BallBase
{
    [SerializeField] private GameObject newBalls;
    public override void StartComponents()
    {
        base.StartComponents();
        StartCoroutine(BallSplitter());
    }

    private void Start()
    {
        StartComponents();
    }

    // Waits for one(1) second then destroys the game object and instantiates the newBalls Prefab 
    // looks like it "splits" on the way down.
    IEnumerator BallSplitter()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Instantiate(newBalls, transform.position, Quaternion.identity);
    }
}
