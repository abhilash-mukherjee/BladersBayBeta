using UnityEngine;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string _scene)
    {
        Time.timeScale = 1;
       GameSceneManager.Instance.LoadScene(_scene);
    }
    public void LoadScene(int _index)
    {
        Time.timeScale = 1;
        GameSceneManager.Instance.LoadScene(_index);
    }
}
