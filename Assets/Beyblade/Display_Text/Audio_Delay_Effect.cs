using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Delay_Effect : MonoBehaviour
{
    // AudioSource drop_sound;

    void Awake(){
        StartCoroutine(DropEffect());
    }

    IEnumerator DropEffect()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
