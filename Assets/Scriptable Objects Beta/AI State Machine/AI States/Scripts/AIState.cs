using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New aI State", menuName ="AI / AI State")]
public class AIState : ScriptableObject
{
    [SerializeField]
    private List<AIAction> actions = new List<AIAction>();
    private AIActionName m_currentActionName;

    public AIActionName CurrentActionName { get => m_currentActionName; set => m_currentActionName = value; }

    public void UpdateState(StateController _enemyStateController,StateController _playerStateController, AIController _AIController )
    {
        AIAction _action = ChooseAction(_enemyStateController,_playerStateController,  _AIController);
        m_currentActionName = _action.ActionName;
        _action.Act(_enemyStateController, _playerStateController, _AIController);
    }

    private AIAction ChooseAction(StateController enemyStateController, StateController playerStateController, AIController aIController)
    {
        if (aIController.TimeSinceLastActionChange <= aIController.ActionChangFrequency)
        {
            var _Action = actions.Find(p => p.ActionName == aIController.CurrentActionName);
            if(_Action == null)
            {
                Debug.LogError("Action is null. ");
            }
            return _Action;
        }
        else
        {
            return actions[UnityEngine.Random.Range(0, actions.Count)];
        }
       
    }
}


public abstract class AIAction : ScriptableObject
{
    [SerializeField]
    private AIActionName m_actionName;

    public AIActionName ActionName { get => m_actionName; }

    public abstract void Act(StateController _enemyStateController, StateController _playerStateController, AIController _AIController);
}
public abstract class AIDecission : ScriptableObject
{
    public abstract bool Decide(StateController _enemyStateController, StateController _playerStateController, AIController _AIController);
}

[System.Serializable]
public class AITransition
{
    [SerializeField]
    private AIDecission[] decissions;
    public List<TransitionPriorityMapping> TrueStatesName, FalseStates;
    [SerializeField]
    private float TrueStateSum, FalseStateSum;
    public bool CheckTransitions(StateController _enemyStateController, StateController _playerStateController, AIController _aiController)
    {
        if (decissions == null)
            return false;
        else if (decissions.Length == 0)
            return false;
        else
        {
            for (int i = 0; i < decissions.Length; i++)
            {
                if (!decissions[i].Decide(_enemyStateController, _playerStateController, _aiController))
                    return false;
            }
            return true;
        }
    }
    [System.Serializable]
    public class TransitionPriorityMapping
    {
        public float priority;
        public AIState AIState;
    }
}
