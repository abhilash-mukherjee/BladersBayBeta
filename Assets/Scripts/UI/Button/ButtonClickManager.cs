using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickManager : MonoBehaviour
{
    public void PlayAudio()
    {
        GameAudioManager.Instance.PlaySoundOneShot("ButtonClick");
    }

    public void PublishEvent(GameEvent _event)
    {
        _event.Raise();
    }

    public void DeactivateObject(GameObject _object)
    {
        _object.SetActive(false);
    }
}
