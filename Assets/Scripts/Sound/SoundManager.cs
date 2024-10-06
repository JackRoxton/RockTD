using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{

    public Sound[] soundsEffects;
    public Sound[] musics;

    public AudioMixer audioMix;

    protected override void Awake()
    {


        base.Awake();

        foreach (Sound s in soundsEffects)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
            {
                Play(s.name);
            }
            s.source.outputAudioMixerGroup = s.output;
        }
        foreach (Sound s in musics)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
            {
                PlayMusic(s.name);
            }
            s.source.outputAudioMixerGroup = s.output;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(soundsEffects, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("sound name not find : " + name);
            return;
        }
        s.source.Play();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("musics name not find : " + name);
            return;
        }
        s.source.Play();
    }

}
