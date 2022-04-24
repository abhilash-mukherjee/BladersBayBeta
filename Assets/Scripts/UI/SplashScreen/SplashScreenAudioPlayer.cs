using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenAudioPlayer : MonoBehaviour
{
    public void PlaySplashAudio1()
    {
        GameAudioManager.Instance.PlaySoundOneShot("SplashScreenAudio1");
    }
    public void PlaySplashAudio2()
    {
        GameAudioManager.Instance.PlaySoundOneShot("SplashScreenAudio2");
    }
    public void PlayBGM()
    {
        GameAudioManager.Instance.PlaySound("BGM1");
    }
}
