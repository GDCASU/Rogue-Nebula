using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] subBars;

    private void Start()       // USE THE LINES BELOW IF USING A HARD CODED EVENT SYSTEM
    {
        //PlayerHealth.onPlayerHurt += DecrementHealth;
        //PlayerHealth.onPlayerHeal += IncrementHealth;
    }

    public void DecrementHealth(int amount)
    {
        int i = subBars.Length - 1;
        while(amount > 0 && i > 0) 
        {
            if (subBars[i] != null)
            {
                if (subBars[i].isActiveAndEnabled)
                {
                    subBars[i].enabled = false;
                    amount--;
                }
            }
            i--;
        }
    }

    public void IncrementHealth(int amount) 
    {
        int i = 0;
        while (amount > 0 && i < subBars.Length)
        {
            if (subBars[i] != null)
            {
                if (!subBars[i].isActiveAndEnabled)
                {
                    subBars[i].enabled = true;
                    amount--;
                }
            }
            i++;
        }
    }
}
