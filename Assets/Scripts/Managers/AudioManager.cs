using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void ChangeSFXVolume(float value)
    {
        _sfxSource.volume = value;
    }

    public void ChangeMusicVolume(float value)
    {
        _musicSource.volume = value;
    }
}
