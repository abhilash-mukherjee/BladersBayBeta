using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent LoadFinishEvent;
    [SerializeField] private DataContext dataContext;
    [SerializeField] private UnitOfWork unitOfWork;
    private static GameDataManager m_instance;
    public UnitOfWork UnitOfWork { get => unitOfWork; }
    public static GameDataManager Instance { get => m_instance;  }

    private void Awake()
    {
        if (m_instance == null) m_instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        var _task = dataContext.Load();
        CheckLoadStatus(_task);
    }
    async void CheckLoadStatus(Task _task)
    {
        while (!_task.IsCompleted) { await Task.Yield(); }
        LoadFinishEvent.Raise();
        Debug.Log("Loaded");
    }
    private void OnApplicationQuit()
    {
        unitOfWork.Save();
        Debug.Log("Saved");
    }
}
