using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObjectTransforms> beyBlades;
    [SerializeField]
    private GameEvent LaunchEvent;
    [SerializeField]
    private float launchDelay = 9f;
    private void Start()
    {
        foreach (var b in beyBlades) b.GameObject.SetActive(false);
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
        foreach (var b in beyBlades) b.GameObject.SetActive(true);
                LaunchEvent.Raise();
    }
    IEnumerator DisableAfterPause(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (var b in beyBlades)
        {
            b.GameObject.SetActive(false);
            b.GameObject.transform.SetPositionAndRotation(b.Transform.position, b.Transform.rotation);
        }

    }
}

[System.Serializable]
public class GameObjectTransforms { public GameObject GameObject; public Transform Transform; }