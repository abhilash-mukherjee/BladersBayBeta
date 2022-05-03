using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTurnOffManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDisable = new List<GameObject>();

    public void TurnOffObjects(float delayTime)
    {
        StartCoroutine(TurnOffObjectsCoroutine(delayTime));
    }
    IEnumerator TurnOffObjectsCoroutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        foreach (var _script in objectsToDisable)
            _script.SetActive(false);
    }
}
