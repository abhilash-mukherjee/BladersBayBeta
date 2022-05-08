using UnityEngine;
[System.Serializable]
public abstract class Base
{
    public string ID
    {
        get => m_id;
        set => m_id = value;
    }
    [SerializeField]private string m_id;
}