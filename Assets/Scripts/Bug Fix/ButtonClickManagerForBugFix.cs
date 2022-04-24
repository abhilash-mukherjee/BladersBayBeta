using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickManagerForBugFix : MonoBehaviour
{
   public void SceneSwitch(int _index)
    {
        SceneManager.LoadScene(_index);
    }
}
