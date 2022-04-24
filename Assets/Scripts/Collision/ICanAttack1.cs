using UnityEngine;

public interface ICanAttack1
{
    GameObject GetAttacker(GameObject _victimObject);
    bool IsAttacker(GameObject _gameObject);
}