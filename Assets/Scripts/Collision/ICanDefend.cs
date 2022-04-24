using UnityEngine;

public interface ICanDefend
{
    GameObject GetVictim(GameObject _attackerObject);
    bool IsVictim(GameObject _gameObject);
}