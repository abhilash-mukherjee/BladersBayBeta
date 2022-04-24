using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance;
    public List<Sound> sounds;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
            s.source.loop = s.loop;

        }
    }
    private void Start()
    {
        PlaySound("BGM1");
    }
    public void PlaySound(string clipName)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else
        {
            audio.source.Play();
        }

    }
    public void PauseSound(string clipName)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else if (audio.source == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else
        {
            if (audio.source.isPlaying)
                audio.source.Stop();
        }

    }

    internal void PlaySoundOneShot(object electricitySoundName)
    {
        throw new NotImplementedException();
    }

    public void PlaySoundOneShot(string clipName)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else
        {
            audio.source.PlayOneShot(audio.source.clip);
        }

    }
    public void PlaySoundWithDecay(string clipName, float decayRate)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
        }
        else
        {
            audio.source.volume = 1f;
            audio.source.Play();
            StartCoroutine(Decay(decayRate, audio.source));
        }

    }
    public bool IsSoundPlaying(string clipName)
    {
        var audio = sounds.First(s => s.name.Equals(clipName));
        if (audio == null)
        {
            Debug.LogWarning("Sound Does not exist");
            return false;
        }
        else
        {
            if (audio.source.isPlaying)
                return true;
            else return false;
        }
    }
   IEnumerator Decay(float decayRate, AudioSource audioSource)
    {
        yield return new WaitForEndOfFrame();
        if (audioSource.volume - decayRate * Time.deltaTime >= 0)
            audioSource.volume -= decayRate * Time.deltaTime;
        StartCoroutine(Decay(decayRate, audioSource));
    }
}
