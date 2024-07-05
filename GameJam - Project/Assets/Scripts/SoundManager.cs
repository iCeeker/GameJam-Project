using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //audiosources
    private AudioSource audiosource;
    public GameObject sourceAudio;

    //soundeffects
    public AudioClip stepsound;
    public AudioClip frying;
    public AudioClip toasterup;
    public AudioClip cutthings;
    public AudioClip endsound;
    public AudioClip bombhit;
    public AudioClip bellding;
    public AudioClip bombhitsplayer;

    //music
    public AudioClip music;

    //volume stuff
    private float Masteringvolume = 0f;

    public static SoundManager Instance;
    public SoundManager()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        sourceAudio = GameObject.FindWithTag("AudioSource");
        audiosource = sourceAudio.GetComponent<AudioSource>();

    }


    public void PlaySound(AudioClip Sound)
    {
        audiosource = sourceAudio.GetComponent<AudioSource>();
        audiosource.PlayOneShot(Sound);
    }

    public void PlaySound(AudioClip Sound, float duration)
    {
        audiosource.PlayOneShot(Sound, duration);
    }
}

