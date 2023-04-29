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
    IEnumerator BallSplitter()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Instantiate(newBalls, transform.position, Quaternion.identity);
    }
}
