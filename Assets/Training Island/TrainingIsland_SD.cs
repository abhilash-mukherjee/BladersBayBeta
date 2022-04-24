using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TrainingIsland_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public BoolVariable isLocked;
    [SerializeField]
    private GameObject image;
    private void Start()
    {
        image.SetActive(!isLocked.Value);
    }

    public void CheckIfButtonActiveAndLoadScene(string _sceneName)
    {
        if(!isLocked.Value)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
