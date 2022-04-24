[System.Serializable]
public class StateAvailabilityTransition 
{
    public StateAvailabilityDecission[] decissions;
    public StateAvailabilityStatus TrueState;
    public StateAvailabilityStatus FalseState;
    public bool AllDecissionsSucced(StateController _stateController, State _state)
    {
        if (decissions == null)
            return false;
        else if (decissions.Length == 0)
            return false;
        else
        {
            for (int i = 0; i < decissions.Length; i++)
            {
                if (decissions[i].Decide(_stateController, _state) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
