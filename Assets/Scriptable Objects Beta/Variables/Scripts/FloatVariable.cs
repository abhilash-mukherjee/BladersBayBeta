using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Float Variable", menuName = "Variables/float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private float floatValue;
    public virtual float Value { get => floatValue; set => floatValue = value; }
}
