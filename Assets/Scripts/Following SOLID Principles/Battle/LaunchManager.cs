using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> beyBlades;
    [SerializeField]
    private GameEvent LaunchEvent;
    [SerializeField]
    private float launchDelay = 9f;
    private void Start()
    {
        foreach (var b in beyBlades) b.SetActive(false);
    }
    public void Launch()
    {
        StartCoroutine(LaunchAfterPause());
       
    }
    public void DisableBeyblades(float time)
    {
        StartCoroutine( DisableAfterPause(time));
    }
    IEnumerator LaunchAfterPause()
    {
        yield return new WaitForSeconds(launchDelay);
        foreach (var b in beyBlades) b.SetActive(true);
                LaunchEvent.Raise();
    }
    IEnumerator DisableAfterPause(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (var b in beyBlades) b.SetActive(false);

    }
}
