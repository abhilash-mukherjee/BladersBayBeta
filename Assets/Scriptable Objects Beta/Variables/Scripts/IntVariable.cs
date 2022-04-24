using UnityEngine;

[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/int")]
public class IntVariable : ScriptableObject
{
    [SerializeField]
    private int value;
    [HideInInspector]
    public virtual int Value { get => value; set => this.value = value; }
}
