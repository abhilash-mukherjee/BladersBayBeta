using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartAnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BattleStarterPrefab;
    public void StartAnimationAfterEventRecieved(float _time)
    {
        StartCoroutine(CallBattleAnimationFunction(_time));
    }
    IEnumerator CallBattleAnimationFunction(float _time)
    {
        yield return new WaitForSeconds(_time);
        StartBattleAnimation();
    }
    private void StartBattleAnimation()
    {
        BattleStarterPrefab.SetActive(true);
    }

}
