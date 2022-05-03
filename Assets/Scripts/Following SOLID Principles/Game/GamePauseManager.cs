using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gamePausePanel;
    void OnEnable()
    {
        BackButtonResponseManager.OnBackButtonPressed += PauseGame;

    }
    void OnDisable()
    {
        BackButtonResponseManager.OnBackButtonPressed -= PauseGame;
    }

    private void PauseGame()
    {
        gamePausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        gamePausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
