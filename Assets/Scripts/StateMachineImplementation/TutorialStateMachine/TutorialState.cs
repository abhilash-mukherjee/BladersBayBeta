using System.Collections;
using System.Collections.Generic;

public abstract class TutorialState
{
    protected TutorialStateMachine tutorialStateMachine;
    public TutorialState(TutorialStateMachine _tutorialStateMachine)
    {
        tutorialStateMachine = _tutorialStateMachine;
    }
    public virtual void Enter()
    {

    }
    public virtual void CheckInput()
    {

    }
    public virtual void Exit()
    {

    }
}
public class TeachMovement_TutorialState : TutorialState
{
    public TeachMovement_TutorialState(TutorialStateMachine _tutorialStateMachine): base(_tutorialStateMachine)
    {
        tutorialStateMachine = _tutorialStateMachine;
    }
}