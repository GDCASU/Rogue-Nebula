using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] int score = 100;

    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = ScoreKeeper.instance;
    }

    protected override void Death()
    {
        scoreKeeper.AddScore(score);

        base.Death();
    }
}
