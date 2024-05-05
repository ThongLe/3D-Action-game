using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource bgm;
    public AudioSource baka;
    //
    public AudioSource attack;
    public AudioSource hurt;
    public AudioSource fly;
    public AudioSource bullet_sound;
    //enemy
    public AudioSource enemy_death;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    //reference this in other script by: SoundManager.Instance.PlaySound(SoundManager.Instance.<name of sound>);
    public void PlaySound(AudioSource sound)
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }
}
