using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent LoadFinishEvent;
    [SerializeField] private DataContext dataContext;
    [SerializeField] private UnitOfWork unitOfWork;
    [SerializeField] private int FTUEBuildIndex = 2, HSBuildIndex = 3;
    [SerializeField] private float splashScreenTime;
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
        StartCoroutine(StartActivityAfterSplashScreen(_task));
    }

    IEnumerator StartActivityAfterSplashScreen(Task _task)
    {
        yield return new WaitForSeconds(splashScreenTime);
        CheckLoadStatus(_task);
    }
    async void CheckLoadStatus(Task _task)
    {
        while (!_task.IsCompleted) { await Task.Yield(); }
        if (!dataContext.Data.GameState.HasBeenOpenedEarlier)
        {
            dataContext.Data.GameState.MaximumLevelUnlocked = 1;
            dataContext.Data.GameState.MaximumTrainingUnlocked = 1;
            dataContext.Data.GameState.HasBeenOpenedEarlier = true;
            SceneManager.LoadScene(FTUEBuildIndex);
        }
        else
        {
            SceneManager.LoadScene(HSBuildIndex);
        }
        LoadFinishEvent.Raise();
        Debug.Log("Loaded");
    }
    private void OnApplicationQuit()
    {
        unitOfWork.Save();
        Debug.Log("Saved");
    }

    private void OnApplicationFocus(bool hasFocus){
        Debug.Log("App is Not Focused" +  hasFocus);
        bool isPaused = !hasFocus;
        if( isPaused ){ 
            unitOfWork.Save();
            if( GameAudioManager.Instance )
                GameAudioManager.Instance.StopAudio();
            Time.timeScale = 0f;
            Debug.Log("Saved");
        }
        else{
            Time.timeScale = 1;
            Debug.Log("App is Focused");

            if( GameAudioManager.Instance )
                GameAudioManager.Instance.StartAudio();

            var _task = dataContext.Load();
            StartCoroutine(StartActivityAfterSplashScreen(_task));

            Debug.Log("Application is Launched");
        }
    }

    private void OnApplicationPause(bool pauseStatus){
        Debug.Log("App is Paused");
        bool isPaused = pauseStatus;
        if( isPaused ){ 
            unitOfWork.Save();
            if( GameAudioManager.Instance )
                GameAudioManager.Instance.StopAudio();
            Time.timeScale = 0f;
            Debug.Log("Saved");
        }
        else{
            Time.timeScale = 1;
            Debug.Log("Application is Started");

            var _task = dataContext.Load();
            StartCoroutine(StartActivityAfterSplashScreen(_task));

            if( GameAudioManager.Instance )
                GameAudioManager.Instance.StartAudio();

            Debug.Log("Application is Launched");
        }
    }
}
