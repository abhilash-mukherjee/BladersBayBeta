using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelData : MonoBehaviour
{
    [SerializeField]
    private Image levelCircleFill, connectingLineFill;
    [SerializeField]
    private float circleFillSpeed, connectingLineFillSpeed;
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private GameObject lockIcon;
    public void LockOrUnlockLevel(bool _isLocked)
    {
        lockIcon.SetActive(_isLocked);
    }

    public LevelData LevelData { get => levelData;}

    public void FillAtOnce(float _levelCircleFillAmount,float _connectingLineFillAmount)
    {
        if(connectingLineFill == null)
        {
            levelCircleFill.fillAmount = _levelCircleFillAmount;
            return;
        }
        levelCircleFill.fillAmount = _levelCircleFillAmount;
        connectingLineFill.fillAmount = _connectingLineFillAmount;
    }
    public void FillWithAnimation(float _levelCircleTargetFillAmount,float _connectingLineTargetFillAmount)
    {
        if (connectingLineFill == null)
        {
            StartCoroutine(FillCircle(_levelCircleTargetFillAmount));
            return;
        }
        StartCoroutine(FillConnectingLine(_connectingLineTargetFillAmount,_levelCircleTargetFillAmount));

    }

    IEnumerator FillCircle(float _targetCircleFill)
    {
        while(levelCircleFill.fillAmount < _targetCircleFill)
        {
            levelCircleFill.fillAmount += Time.deltaTime * circleFillSpeed;
            yield return null;
        }
        
    }
    IEnumerator FillConnectingLine(float _targetLineFill, float _targetCircleFill)
    {
        while(connectingLineFill.fillAmount < _targetLineFill)
        {
            connectingLineFill.fillAmount += Time.deltaTime * connectingLineFillSpeed;
            yield return null;
        }
        StartCoroutine(FillCircle(_targetCircleFill));
    }
}
