using UnityEngine;
[System.Serializable]
public class FloatReference 
{
    public bool isConstant;
    public float constantValue;
    public FloatVariable variable;
    public float Value
    {
        get { return isConstant ? constantValue : variable.Value; }
    }
}

