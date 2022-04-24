using System.Collections;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField]
    private float splashScreenEndTime = 10f;
    [SerializeField]
    private string nextSceneName;
    private void Start()
    {
        StartCoroutine(EndSplashScreen());
    }
    IEnumerator EndSplashScreen()
    {
        yield return new WaitForSeconds(splashScreenEndTime);
        GameSceneManager.Instance.LoadScene(nextSceneName);
    }
}
