using System.Collections;
using UnityEngine;

public class TimeRegulator : MonoBehaviour
{
    [SerializeField]
    private float timeStepAfterCollision = 0.5f;
    [SerializeField]
    private float slowTillWhen = 1f;
    [SerializeField]
    private float resumeRate = 0.05f;
    public void SlowTime()
    {
        Time.timeScale = timeStepAfterCollision;
        StartCoroutine(NormalizeTime());
    }
    IEnumerator NormalizeTime()
    {
        yield return new WaitForSecondsRealtime(slowTillWhen);
        while(Time.timeScale < 1f)
        {
            Time.timeScale += resumeRate;
            yield return null;
        }
        Time.timeScale = 1f;
    }

}
