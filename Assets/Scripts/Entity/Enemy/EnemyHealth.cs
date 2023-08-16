using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] public int score = 100;

    private ScoreKeeper scoreKeeper;

    // Events
    public static event Action<GameObject> onEnemyDeath;

    private void Start()
    {
        scoreKeeper = ScoreKeeper.instance;
    }

    protected override void Death()
    {
        scoreKeeper.AddScore(score);
        onEnemyDeath?.Invoke(gameObject);
        base.Death();
    }
}
