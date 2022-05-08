using System;
using UnityEngine;

[Serializable]
public class Level : Base
{
    public delegate void LevelDataChangeHandler(string _id);
    public static event LevelDataChangeHandler OnLevelDataChanged;
    [SerializeField] private int levelIndex;
    [SerializeField] private bool isLevelVisited;
    [SerializeField] private bool isLevelRecentlyWon;
    [SerializeField] private bool isLevelCleared;
    public Level(int _levelIndex, string _id)
    {
        levelIndex = _levelIndex;
        isLevelVisited = false;
        isLevelRecentlyWon = false;
        isLevelCleared = false;
        ID = _id;
    }
    public int LevelIndex 
    {
        get => levelIndex;
        set
        {
            levelIndex = value;
            OnLevelDataChanged?.Invoke(ID);
        }
    }
    public bool IsLevelVisited
    {
        get => isLevelVisited;
        set
        {
            isLevelVisited = value;
            OnLevelDataChanged?.Invoke(ID);
        }
    }
    public bool IsLevelRecentlyWon
    {
        get => isLevelRecentlyWon;
        set
        {
            isLevelRecentlyWon = value;
            OnLevelDataChanged?.Invoke(ID);
        }
    }
    public bool IsLevelCleared
    {
        get => isLevelCleared;
        set
        {
            isLevelCleared = value;
            OnLevelDataChanged?.Invoke(ID);
        }
    }
}
