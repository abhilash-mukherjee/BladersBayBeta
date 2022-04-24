using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsDisplayManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> uIComponents = new List<GameObject>();
    public void MakeActiveAfterGivenTime(float _time)
    {
        StartCoroutine(CallChangeVisibilityFunction(_time, true));
    }
    public void MakeInActiveAfterGivenTime(float _time)
    {
        StartCoroutine(CallChangeVisibilityFunction(_time, false));
    }
    IEnumerator CallChangeVisibilityFunction(float _time, bool _finalStatus)
    {
        yield return new WaitForSeconds(_time);
        ChangeVisibilityOfUIComponents(_finalStatus);
    }
    private void ChangeVisibilityOfUIComponents(bool _finalStatus)
    {
        foreach (var _gO in uIComponents)
        {
            _gO.SetActive(_finalStatus );
        }
    }
}
