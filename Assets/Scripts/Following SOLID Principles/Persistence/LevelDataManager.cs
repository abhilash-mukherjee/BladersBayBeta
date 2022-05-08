using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    [SerializeField] public UnitOfWork unitOfWork;
    [SerializeField] private DataContext dataContext;
    [SerializeField] private int levelCount, trainingCount;
    private void OnEnable()
    {
        LevelResultDecider.OnResultDecided += UpdateLevelData;
    }
    private void OnDisable()
    {
        LevelResultDecider.OnResultDecided -= UpdateLevelData;
    }
    public void UpdateLevelData(Result result, string _levelID)
    {
        var _level = unitOfWork.Levels.GetByID(_levelID);
        var _progress = dataContext.Data.GameState;
        _level.IsLevelVisited = true;
        if (result == Result.PLAYER_WON)
        {
            if (!_level.IsLevelCleared)
            {
                _level.IsLevelCleared = true;
                _level.IsLevelRecentlyWon = true;
                _progress.DidLastBattleUnlockNewLevel = true;
                _progress.MaximumLevelUnlocked++;
            }
            else
            {
                _level.IsLevelRecentlyWon = false;
                _progress.DidLastBattleUnlockNewLevel = false;
            }
            return;
        }
        else
        {
            _progress.DidLastBattleUnlockNewLevel = false;
            _level.IsLevelRecentlyWon = false;
        }
    }

    public void OnDataLoaded()
    {
        if (dataContext.Data.levels.Count > 0) return;
        for(int i = 0; i < levelCount; i++)
        {
            unitOfWork.Levels.Add(new Level(i + 1, "LEVEL_" + (i + 1)));
        }
        for(int i = 0; i < trainingCount; i++)
        {
            unitOfWork.Levels.Add(new Level(i + 1, "TRAINING_" + (i + 1)));
        }
        unitOfWork.Save();
    }

}

[System.Serializable] public enum Result { PLAYER_WON, PLAYER_LOST }
