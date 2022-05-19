using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausePanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    public GameEvent enablBackButton;
    public void SowResumePanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        GameAudioManager.Instance.StartAudio();
        
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        enablBackButton.Raise();
        panel.SetActive(false);
    }
    public void Pause()
    {
        GameAudioManager.Instance.StartAudio();
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

}
