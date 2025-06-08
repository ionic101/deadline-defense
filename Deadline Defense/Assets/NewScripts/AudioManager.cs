using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private Sound s;

    public static AudioManager instance;

    void Awake()
    {
        foreach (Sound s in sounds) 
        { 
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume; 
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }   
        
    }

    private void Start()
    {
        Play("MainTheme");
    }



    public void Play(string name)
    {
        s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            s.source.Play();
    }

    public void PauseMusic()
    {
        s.source.Pause();
    }

    public void UnPauseMusic() 
    {
        s.source.UnPause();
    }

    public void StopMusic()
    {
        s.source?.Stop();
    }
}
