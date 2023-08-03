using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] int score = 100;

    ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score Keeper").GetComponent<ScoreKeeper>();
    }

    protected override void Death()
    {
        scoreKeeper.AddScore(score);

        base.Death();
    }
}
