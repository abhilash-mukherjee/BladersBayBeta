using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string _scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_scene);
    }
    public void LoadScene(int _index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_index);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
