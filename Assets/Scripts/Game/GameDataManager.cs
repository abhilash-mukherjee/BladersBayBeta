using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData PlayerData;
    [SerializeField]
    private BeyBladeInventory inventory;
    [SerializeField]
    private List<LevelData> levelDataList = new List<LevelData>();

    private void Awake()
    {
        LoadSavedData();
    }

    private void LoadSavedData()
    {
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
    }

    private void OnApplicationPause(bool _pauseStatus)
    {
        SaveData();
        
    }


}
