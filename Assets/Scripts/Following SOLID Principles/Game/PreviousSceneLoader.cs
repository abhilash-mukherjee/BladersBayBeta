using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousSceneLoader : MonoBehaviour
{
    public void LoadPreviousScene(string _scene)
    {
        GameSceneManager.Instance.LoadScene(_scene);
    }
}
