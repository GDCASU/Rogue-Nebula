using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlidersUI : MonoBehaviour
{
    [SerializeField] private Slider _sfxSlider, _musicSlider;

    private void Start()
    {
        _sfxSlider.value = AudioManager.instance.GetSoundVolume();
        _musicSlider.value = AudioManager.instance.GetMusicVolume();

        _sfxSlider.onValueChanged.AddListener(val => AudioManager.instance.ChangeSFXVolume(val));
        _musicSlider.onValueChanged.AddListener(val => AudioManager.instance.ChangeMusicVolume(val));
    }
}
