using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public Image bubbleShieldCDImage;
    public Image evadeCDImage;

    private bool bubbleShieldOnCooldown = false;
    private float bubbleShieldCooldownTime = 0f;

    private bool evadeOnCooldown = false;
    private float evadeCooldownTime = 0f;


    private void Start()
    {
        bubbleShieldCDImage.fillAmount = 0;
        evadeCDImage.fillAmount = 0;
    }
    private void Update()
    {
        if (bubbleShieldOnCooldown)
            BubbleShieldOnCooldown(bubbleShieldCooldownTime);
        if (evadeOnCooldown)
            EvadeOnCooldown(evadeCooldownTime);
    }

    public void StartBubbleShieldCooldown(float cooldownTime)
    {
        bubbleShieldCDImage.fillAmount = 1;
        bubbleShieldOnCooldown = true;
        bubbleShieldCooldownTime = cooldownTime;
    }

    public void StartEvadeCooldown(float cooldownTime)
    {
        evadeCDImage.fillAmount = 1;
        evadeOnCooldown = true;
        evadeCooldownTime = cooldownTime;
    }

    public void BubbleShieldOnCooldown(float cooldownTime)
    {
        bubbleShieldCDImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;

        if (bubbleShieldCDImage.fillAmount <= 0)
        {
            bubbleShieldCDImage.fillAmount = 0;
            bubbleShieldOnCooldown = false;
        }
    }

    public void EvadeOnCooldown(float cooldownTime)
    {
        evadeCDImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;

        if (evadeCDImage.fillAmount <= 0)
        {
            evadeCDImage.fillAmount = 0;
            evadeOnCooldown = false;
        }
    }
}
