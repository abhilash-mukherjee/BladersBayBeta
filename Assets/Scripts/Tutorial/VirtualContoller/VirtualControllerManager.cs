using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualControllerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject backPart;
    [SerializeField]
    private VectorVariable ControllerPosition, ControllerUpAxis;
    private Vector3 m_backPartPosition;
    private Transform m_transform;
    public Vector3 ControllerMouthPosition
    {
        get { return m_backPartPosition; }
    }
    private void Awake()
    {
        m_transform = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Stadium"))
            return;
        m_backPartPosition = backPart.transform.position;
        var _upAxis = m_transform.up;
        ControllerPosition.SetValue( m_backPartPosition.x, m_backPartPosition.y, m_backPartPosition.z);
        ControllerUpAxis.SetValue(_upAxis.x, _upAxis.y, _upAxis.z);
        
    }
}
