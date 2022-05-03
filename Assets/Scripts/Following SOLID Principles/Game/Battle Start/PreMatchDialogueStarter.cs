using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreMatchDialogueStarter : MonoBehaviour
{
    [SerializeField]
    private SessionController sessionController;
    void Start()
    {
        sessionController.StartSession();
    }

   
}
