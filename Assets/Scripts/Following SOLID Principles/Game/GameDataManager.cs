using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent LoadFinishEvent, pausedEvent, resumedEvent;
    [SerializeField] private DataContext dataContext;
    [SerializeField] private UnitOfWork unitOfWork;
    [SerializeField] private int FTUEBuildIndex = 2, HSBuildIndex = 3;
    [SerializeField] private float splashScreenTime;
    private static GameDataManager m_instance;
    private bool m_isLodingFresh = true;
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
        Debug.Log("App launched");
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
        Debug.Log("Loaded at the begining");
    }
    private void OnApplicationQuit()
    {
        unitOfWork.Save();
        Debug.Log("Saved");
    }

    private void OnApplicationPause(bool pauseStatus){
        bool isPaused = pauseStatus;
        if( isPaused )
        {
            Debug.Log("App is Paused");
            unitOfWork.Save();
            if( GameAudioManager.Instance != null)
                GameAudioManager.Instance.StopAudio();
            Time.timeScale = 0f;
            pausedEvent.Raise();
            Debug.Log("Saved");
        }
        else
        {
            if (m_isLodingFresh)
            {
                m_isLodingFresh = false;
                return;
            }
            Debug.Log("Application is resumed");
            var _task = dataContext.Load();
            CheckLoadStatusAfterPause(_task);
        }
    }
    async void CheckLoadStatusAfterPause(Task _task)
    {
        while (!_task.IsCompleted) { await Task.Yield(); }
        Time.timeScale = 1f;
        LoadFinishEvent.Raise();
        Debug.Log("Loaded after pause");
        resumedEvent.Raise();

    }
}
