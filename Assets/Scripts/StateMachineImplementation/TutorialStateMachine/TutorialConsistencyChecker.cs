using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialConsistencyChecker : MonoBehaviour
{
    [SerializeField]
    private TutorialManager tutorialManager;
    [SerializeField]
    private CanvasDisplayManager canvasDisplayManager;
    private void Start()
    {
        if(CustomCommand.customCommandsInCurrentScene.Count != tutorialManager.CommandListCount)
        {
            Debug.LogError("All custom commands in the scene are not added to the Tutorial Manager");
            Debug.LogError($"Cusom Command List: {CustomCommand.customCommandsInCurrentScene.ToString()} " +
                "But Tutorial manager has {tutorialManager.CommandListCount} commands");
        }
        if(CustomCommand.customCommandsInCurrentScene.Count != canvasDisplayManager.DisplayableSlotListCount)
        {
            Debug.LogError("All custom commands in the scene do not have a corresponding UI to show");
        }
        if(tutorialManager.CommandListCount != canvasDisplayManager.DisplayableSlotListCount)
        {
            Debug.LogError("All tutorial commands do not have a corresponding UI to show");
        }
    }
}
