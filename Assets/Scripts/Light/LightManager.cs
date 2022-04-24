using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField]
    private Light Light;
    [SerializeField]
    private float normalIntensity, specialModeIntensity, battleEndIntensity, lerpSpeed = 10f;
    [SerializeField]
    private BeyBladeStateName balanceStateName;
    [SerializeField]
    private List<StateController> stateControllers = new List<StateController>();
    private bool m_hasBattleEnded = false;
    public void TurnOffLight(float time)
    {
        StartCoroutine(LightTurnOffCoroutine(time));
    }
    IEnumerator LightTurnOffCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        m_hasBattleEnded = true;
    }
    private void Update()
    {
        UpdateLightDuringSpecialMode();
        LerpLightIntensity();
    }

    private void LerpLightIntensity()
    {
        if (!m_hasBattleEnded)
            return;
        Light.intensity = Mathf.Lerp(Light.intensity, battleEndIntensity, Time.deltaTime * lerpSpeed);
    }

    private void UpdateLightDuringSpecialMode()
    {
        if (m_hasBattleEnded)
            return;
        foreach (var c in stateControllers)
        {
            if (c == null)
                continue;
            if (c.CurrentState.Name != balanceStateName)
            {
                Light.intensity = specialModeIntensity;
                break;
            }
            else Light.intensity = normalIntensity;
        }
    }
}
