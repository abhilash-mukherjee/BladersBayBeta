using UnityEngine;

[CreateAssetMenu(fileName = "New Check If Player Died", menuName = "State Machine / Decissions / Check If Player Died")]
public class HasPlayerDied : Decission
{
    public override bool Decide(StateController _stateCntroller, State _state)
    {
        if (_stateCntroller.GetComponent<BeyBladeHealthManager>().HasDied())
            return true;
        return false;
    }
}
