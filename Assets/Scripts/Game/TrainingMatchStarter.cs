using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingMatchStarter : MonoBehaviour
{

    [SerializeField]
    private GameEvent OnMatchStarted;
    public void Start()
    {
        OnMatchStarted.Raise();
    }


}
