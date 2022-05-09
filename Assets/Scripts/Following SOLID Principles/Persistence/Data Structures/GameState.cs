using System;
using UnityEngine;

[Serializable]
public class GameState : Base
{
    [SerializeField] private int maximumLevelUnlocked;
    [SerializeField] private int maximumTrainingUnlocked;
    [SerializeField] private bool didLastBattleUnlockNewLevel;
    [SerializeField] private bool didLastBattleUnlockNewTrainingLevel;
    [SerializeField] private int levelCount, trainingCount;
    public int MaximumLevelUnlocked { get => maximumLevelUnlocked; set => maximumLevelUnlocked = value; }
    public int MaximumTrainingUnlocked { get => maximumTrainingUnlocked; set => maximumTrainingUnlocked = value; }
    public bool DidLastBattleUnlockNewLevel { get => didLastBattleUnlockNewLevel; set => didLastBattleUnlockNewLevel = value; }
    public bool DidLastBattleUnlockNewTrainingLevel { get => didLastBattleUnlockNewTrainingLevel; set => didLastBattleUnlockNewTrainingLevel = value; }
    public int LevelCount { get => levelCount; set => levelCount = value; }
    public int TrainingCount { get => trainingCount; set => trainingCount = value; }
}
