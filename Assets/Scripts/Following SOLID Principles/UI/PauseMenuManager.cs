using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField]
    private PanelDisplayable pauseMenu;
    private bool m_isGamePaused = false;
    private void Start()
    {
        m_isGamePaused = false;
    }
    public void PauseOrResumeGame()
    {
        if (!m_isGamePaused)
        {
            Time.timeScale = 0f;
            m_isGamePaused = true;
            pauseMenu.EnterForward();
        }
        else
        {
            Time.timeScale = 1f;
            m_isGamePaused = false;
            pauseMenu.ExitForward();
        }
    }
}
