using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private AudioSource audioSource;
    private AudioSource playerAudioSource;
    //Music
    [SerializeField] public AudioClip backgroundMusic;

    //SFX
    [SerializeField] public AudioClip pistolShot;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerAudioSource = _player.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusic;

        if (Camera.main != null && Camera.main.GetComponent<AudioListener>() == null)
        {
            Camera.main.gameObject.AddComponent<AudioListener>();
        }

        PlayMusic();
    }

    public void PlayMusic()
    {
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    public void PlaySound(string sfxType)
    {
        if (sfxType == "Pistol") 
        {
            playerAudioSource.clip = pistolShot;
        }
        else
        {
            playerAudioSource.clip = null;
        }

        playerAudioSource.volume = 0.2f;
        playerAudioSource.Play();
    }

}
