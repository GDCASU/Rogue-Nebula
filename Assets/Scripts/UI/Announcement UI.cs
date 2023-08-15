using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Transactions;

public class AnnouncementUI : MonoBehaviour
{
    private const string ANNOUNCEMENT_HEADER = "WAVE INCOMING ";

    [SerializeField] private TMP_Text announcementText;
    [SerializeField] private Color easyTextColor, mediumTextColor, hardTextColor;
    [SerializeField] private int blinkCount = 5;
    [SerializeField] private float blinkDelay = 0.2f;

    private Color currentColor;

    private void Start()
    {
        announcementText.enabled = false;
        WaveManager.onWaveStart += AnnouceWave;
        currentColor = easyTextColor;
    }

    private void AnnouceWave(int waveNum)
    {
        WaveDifficulty currentWaveDifficulty = WaveManager.instance.currentDifficulty;

        switch (currentWaveDifficulty) 
        {
            default:
                break;
            case WaveDifficulty.easy:
                currentColor = easyTextColor;
                break;
            case WaveDifficulty.medium:
                currentColor = mediumTextColor;
                break;
            case WaveDifficulty.hard:
                currentColor = hardTextColor;
                break;
        }

        if (waveNum < 10)
            announcementText.text = ANNOUNCEMENT_HEADER + '0' + waveNum;
        else if (waveNum >= 99)
            announcementText.text = ANNOUNCEMENT_HEADER + "99";
        else
            announcementText.text = ANNOUNCEMENT_HEADER + waveNum;

        StartCoroutine(AnnounceWaveCo());
    }

    private IEnumerator AnnounceWaveCo()
    {
        announcementText.enabled = true;
        announcementText.color = currentColor;
        for (int i = 0; i < blinkCount; i++)
        {
            yield return new WaitForSeconds(blinkDelay);
            SwitchColor();
        }
        announcementText.enabled = false;
    }

    bool isWhite = false;
    private void SwitchColor()
    {
        if (isWhite)
        {
            announcementText.color = currentColor;
            isWhite = false;
        }
        else
        {
            announcementText.color = Color.white;
            isWhite = true;
        }
    }
}
