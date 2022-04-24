using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvasDisplay : MonoBehaviour
{
    [SerializeField]
    private CanvasDisplayManager canvasDisplayManager;
    private void Start()
    {
        canvasDisplayManager.StartDisplay();
        Debug.Log("Display started");
    }
}
