using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemy : IEnemy
{
    private void Update()
    {
        
    }

    // Moves the enemy in a random direction then looks at the player
    protected override void Move()
    {
        // Rotate to a random position
        float direction = Random.Range(0, 360);
        transform.Rotate(transform.forward, direction);


    }
}
