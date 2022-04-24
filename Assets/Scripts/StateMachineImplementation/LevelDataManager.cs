using UnityEngine;

public class LevelDataManager: MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private GameObject player;
    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += UpdateLevelData;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= UpdateLevelData;
        
    }
    public void UpdateLevelData(GameObject _winner, GameObject _looser)
    {
        if(player != _winner)
        {
            playerData.DidLastBattleUnlockNewLevel.Value = false;
            return;
        }
        if (levelData.LevelIndex == playerData.MaximumLevelUnlocked.Value)
        {
            Debug.Log("New level unlocked");
            playerData.DidLastBattleUnlockNewLevel.Value = true;
            playerData.MaximumLevelUnlocked.Value++;
        }
        else playerData.DidLastBattleUnlockNewLevel.Value = false;
        levelData.MarkLevelAsVisited();

    }

}