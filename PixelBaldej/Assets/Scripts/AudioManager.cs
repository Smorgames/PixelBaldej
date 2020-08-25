using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.audioClip;

            sound.source.loop = sound.loop;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    private void Start()
    {
        Play("MainTheme1");
    }

    public void Play(string soundName)
    {
        Sound soundToPlay = Array.Find(sounds, sound => sound.name == soundName);

        if (soundToPlay == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }

        soundToPlay.source.Play();
    }
}
