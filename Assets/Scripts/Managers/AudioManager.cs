using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum Music
{
    Menu,
    Game,
    GameOver
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [SerializeField] private AudioClip _menuMusic, _gameMusic, _gameOverMusic;

    //Components
    private AudioHighPassFilter _musicHighPassFilter;

    private void Awake()        // Handle Singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _musicHighPassFilter = _musicSource.GetComponent<AudioHighPassFilter>();
        _musicHighPassFilter.enabled = false;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip !=  null)
            _sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(Music track)
    {
        //if (_musicSource.isPlaying)
           // StopMusicTrack();

        _musicSource.pitch = 1;
        if (_musicSource != null)
        {
            switch (track)
            {
                case Music.Menu:
                    _musicSource.clip = _menuMusic;
                    _musicSource.Play();
                    break;
                case Music.Game:
                    _musicSource.clip = _gameMusic;
                    _musicSource.Play();
                    break;
                case Music.GameOver:
                    _musicSource.clip = _menuMusic;
                    _musicSource.Play();
                    break;
            }
        }
    }

    public void ChangeSFXVolume(float value)
    {
        _sfxSource.volume = value;
    }

    public void ChangeMusicVolume(float value)
    {
        _musicSource.volume = value;
    }

    public void StopMusicTrack()
    {
        _musicSource.Stop();
    }

    public void PauseMenuResonance(bool toggle)
    {
        _musicHighPassFilter.enabled = toggle;
    }
}
