using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon_SD : MonoBehaviour
{
    [SerializeField]
    private bool isClicked = true;

    [SerializeField]
    private GameObject inActiveGameObject;

    public void ComingSoon(){
        gameObject.SetActive(true);
        if(inActiveGameObject)
            inActiveGameObject.SetActive(false);
    }

    public void ClosedVoid(){
        gameObject.SetActive(false);
        if(inActiveGameObject)
            inActiveGameObject.SetActive(true);
    }
}
