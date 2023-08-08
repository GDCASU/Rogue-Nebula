using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image[] subBars;

    private void Start()       // USE THE LINES BELOW IF USING A HARD CODED EVENT SYSTEM
    {
        //PlayerHealth.onPlayerHurt += DecrementHealth;
        //PlayerHealth.onPlayerHeal += IncrementHealth;
        CurrentSubbarFlashAnim();
    }

    public void DecrementHealth(int amount)
    {
        int i = subBars.Length - 1;
        while (amount > 0 && i > 0)
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
        CurrentSubbarFlashAnim();
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
        CurrentSubbarFlashAnim();
    }

    private void CurrentSubbarFlashAnim()
    {
        Animator anim;
        int i = subBars.Length - 1;
        while (i >= 0)
        {
            if (subBars[i] != null)
            {
                anim = subBars[i].GetComponent<Animator>();
                if (anim != null)
                {
                    if (subBars[i].isActiveAndEnabled)
                    {
                        anim.SetBool("isFlashing", true);
                        break;
                    }
                    anim.SetBool("isFlashing", false);
                }
            }
            i--;
        }
    }
}
