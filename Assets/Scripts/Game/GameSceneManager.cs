using JMRSDK.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    public delegate void SceneLoadHandler();
    public static event SceneLoadHandler OnGameSceneLoaded;
    [SerializeField]
    private List<string> sceneNames;
    private Stack<Scene> sceneStack = new Stack<Scene>();
    private List<Scene> sceneList = new List<Scene>();
    private Scene currentScene;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
    private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene _scene)
    {
        //sceneStack.Push(sceneList.Find(p => p.name == _scene.name));
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene _scene, LoadSceneMode arg1)
    {
        //var _checkScene = sceneList.Find(p => p.name == _scene.name);
        //if (_checkScene != null)
        //{
        //    currentScene = _checkScene;
        //    return;
        //}
        //currentScene = new Scene(_scene.name);
        //sceneList.Add(currentScene);
        //OnGameSceneLoaded?.Invoke();
        //FindObjectOfType<JMRInputManager>().gameObject.GetComponent<JMRPointerManager>().enabled = true;
    }



    public void PlayGame()
    {
        Debug.Log("Play Again");
        SceneManager.LoadScene("GamePlay");
    }

    public void LoadScene(string _sceneName)
    {
        currentScene = new Scene(_sceneName);
        SceneManager.LoadScene(_sceneName);
        
    }
    public void LoadScene(int _index)
    {
        Time.timeScale = 1;
        //currentScene = new Scene(_sceneName);
        SceneManager.LoadScene(_index);
        
    }
    //public void LoadPreviousScene()
    //{
    //    SceneManager.LoadScene(sceneStack.Pop().name);
        
    //}
    
}

[System.Serializable]
public class Scene
{
    public string name;
    public Scene(string name)
    {
        this.name = name;
    }
}