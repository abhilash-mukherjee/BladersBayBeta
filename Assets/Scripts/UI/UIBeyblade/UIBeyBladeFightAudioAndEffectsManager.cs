using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBeyBladeFightAudioAndEffectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueBey, redBey;
    [SerializeField]
    private string collisionAudioName = "BeyBladeHit";
    [SerializeField]
    private GameObject collisionEffect;
    public void Collided()
    {
        PlayAudio();
        PlayVFX();
    }

    private void PlayAudio()
    {
        GameAudioManager.Instance.PlaySoundOneShot(collisionAudioName);
    }

    private void PlayVFX()
    {
        Instantiate(collisionEffect, (blueBey.transform.position + redBey.transform.position) * 0.5f, Quaternion.identity);
    }
}
