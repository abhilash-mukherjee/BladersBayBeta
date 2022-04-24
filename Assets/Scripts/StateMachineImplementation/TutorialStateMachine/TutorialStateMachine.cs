using System;
using UnityEngine;

public abstract class TutorialStateMachine: MonoBehaviour
{
    protected TutorialState state;
    public void ChangeState(TutorialState _state)
    {
        state = _state;
    }
}

public class TutorialSystem: TutorialStateMachine
{
    private void Start()
    {
        BeginTutorial();
    }

    private void BeginTutorial()
    {
        state = new TeachMovement_TutorialState(this);
    }
}