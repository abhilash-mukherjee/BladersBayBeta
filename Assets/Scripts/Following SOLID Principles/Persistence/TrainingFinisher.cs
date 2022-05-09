using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingFinisher : MonoBehaviour
{
    public delegate void TrainingFinishHandler(string _id);
    public static event TrainingFinishHandler OnTrainingLevelCompleted;
    [SerializeField] private string TrainingName = "TRAINING_";
    public void TrainingLevelCompleted()
    {
        OnTrainingLevelCompleted?.Invoke(TrainingName);
    }
}
