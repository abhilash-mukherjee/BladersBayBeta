using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    [SerializeField] public UnitOfWork unitOfWork;
    [SerializeField] private DataContext dataContext;
    [SerializeField] private int levelCount, trainingCount;
    private void OnEnable()
    {
        LevelResultDecider.OnResultDecided += UpdateLevelData;
        TrainingFinisher.OnTrainingLevelCompleted += UpdateTrainingData;
    }

    private void OnDisable()
    {
        LevelResultDecider.OnResultDecided -= UpdateLevelData;
        TrainingFinisher.OnTrainingLevelCompleted -= UpdateTrainingData;
    }
    private void UpdateTrainingData(string _id)
    {
        var _trainingLevel = unitOfWork.Levels.GetByID(_id);
        var _progress = dataContext.Data.GameState;
        _trainingLevel.IsLevelVisited = true;
            if (!_trainingLevel.IsLevelCleared)
            {
                _trainingLevel.IsLevelCleared = true;
                _trainingLevel.IsLevelRecentlyWon = true;
                _progress.DidLastBattleUnlockNewTrainingLevel = true;
                _progress.MaximumTrainingUnlocked++;
            }
            else
            {
                _trainingLevel.IsLevelRecentlyWon = false;
                _progress.DidLastBattleUnlockNewTrainingLevel = false;
            }
        unitOfWork.Save();

        return;
     
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
            unitOfWork.Save();
            return;
        }
        else
        {
            _progress.DidLastBattleUnlockNewLevel = false;
            _level.IsLevelRecentlyWon = false;
            unitOfWork.Save();
        }
    }

    public void OnDataLoaded()
    {
        if (dataContext.Data.levels.Count > 0) return;
        for(int i = 0; i < levelCount; i++)
        {
            unitOfWork.Levels.Add(new Level("LEVEL_" + (i + 1)));
        }
        for(int i = 0; i < trainingCount; i++)
        {
            unitOfWork.Levels.Add(new Level("TRAINING_" + (i + 1)));
        }
        unitOfWork.Save();
    }

}

[System.Serializable] public enum Result { PLAYER_WON, PLAYER_LOST }
