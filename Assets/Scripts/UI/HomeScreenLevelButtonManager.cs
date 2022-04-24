using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenLevelButtonManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData PlayerData;
    [SerializeField]
    private int levelNumber;
    [SerializeField]
    private string levelToLoad = "Level ";
    [SerializeField]
    private string buttonClickSound;
    public void LevelButtonClicked()
    {
        if(PlayerData.MaximumLevelUnlocked.Value < levelNumber)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
            GameAudioManager.Instance.PlaySoundOneShot(buttonClickSound);
        }
    }

}
