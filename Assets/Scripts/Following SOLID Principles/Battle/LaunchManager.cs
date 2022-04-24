using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player, enemy;
    [SerializeField]
    private GameEvent LaunchEvent;
    [SerializeField]
    private float launchDelay = 9f;
    private void Awake()
    {
        player.SetActive(false);
        enemy.SetActive(false);
    }
    public void Launch()
    {
        StartCoroutine(LaunchAfterPause());
       
    }
    IEnumerator LaunchAfterPause()
    {
        yield return new WaitForSeconds(launchDelay);
        player.SetActive(true);
        enemy.SetActive(true);
        LaunchEvent.Raise();
    }
}
