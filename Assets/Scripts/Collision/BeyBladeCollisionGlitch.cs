using System.Collections.Generic;
using UnityEngine;

public class BeyBladeCollisionGlitch : IGlitchyCollision
{
    private ICollidingBeyBlade m_beyBlade1, m_beyBlade2;
    public ICollidingBeyBlade BeyBlade1 => throw new System.NotImplementedException();

    public ICollidingBeyBlade BeyBlade2 => throw new System.NotImplementedException();

    public BeyBladeCollisionGlitch(GameObject _player1, GameObject _player2)
    {
        m_beyBlade1 = new CollidingBeyBladeWithGlitch(_player1.GetComponent<CharacterController>(), _player1.transform.position,
            _player2.transform.position - _player1.transform.position);
        m_beyBlade2 = new CollidingBeyBladeWithGlitch(_player2.GetComponent<CharacterController>(), _player2.transform.position,
            _player1.transform.position - _player2.transform.position);
    }

    public  bool CheckIfPassedGameObjectIsInvolvedInCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject || m_beyBlade2.BeyBladeObject == _gameObject)
            return true;
        else
            return false;
    }

  
    public  Vector3 GetVelocityAfterCollision(GameObject _gameObject)
    {
        if (m_beyBlade1.BeyBladeObject == _gameObject)
        {
            return m_beyBlade1.VelocityAfterCollision ;
        }
        else if (m_beyBlade2.BeyBladeObject == _gameObject)
        {
            return m_beyBlade2.VelocityAfterCollision;
        }
        else return Vector3.zero;
    }

}