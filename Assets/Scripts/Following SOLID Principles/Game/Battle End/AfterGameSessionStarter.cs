using System.Collections;
using UnityEngine;

public class AfterGameSessionStarter : MonoBehaviour
{
    [SerializeField]
    private SessionController sessionToStart;
    public void StartSessionAfterMatchEnd(float time)
    {
        StartCoroutine(StartSession(time));
    }

    IEnumerator StartSession(float time)
    {
        yield return new WaitForSeconds(time);
        sessionToStart.StartSession();
    }
}
