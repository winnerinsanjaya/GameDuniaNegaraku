using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSound : MonoBehaviour
{

    public Sound[] sounds;
    public AnswerSound Asnwersoundinstance;
    private bool atFirst;

    private string lastPlayed;
    private void Awake()
    {
        atFirst = true;
        if (Asnwersoundinstance == null)
        {
            Asnwersoundinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {

        StopPlay();
        atFirst = false;
        StartCoroutine(PlaySec(name));
        Debug.Log(name);
    }

    public void StopPlay()
    {
        if (atFirst == false)
        {
            Sound s = Array.Find(sounds, sound => sound.name == lastPlayed);
            s.source.Stop();
        }

    }

    IEnumerator PlaySec(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        lastPlayed = name;
        yield return new WaitForSecondsRealtime(100f);
        s.source.Stop();
    }
}