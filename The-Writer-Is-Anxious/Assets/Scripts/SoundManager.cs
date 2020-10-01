using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource myaudio;

    public List<AudioClip> musics;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        myaudio = GetComponent<AudioSource>();
    }

    public void Play(int i)
    {
        myaudio.clip = musics[i];
        myaudio.Play();
    }

    public void Stop()
    {
        myaudio.Stop();
    }
}
