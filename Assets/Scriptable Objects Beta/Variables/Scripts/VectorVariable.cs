using UnityEngine;

[CreateAssetMenu(fileName = "New Vctor Variable", menuName = "Variables/Vector")]
public class VectorVariable : ScriptableObject
{
    [SerializeField]
    protected Vector3 Vector;
    public virtual Vector3 Value 
    { 
        get => Vector; 
    }

    public void SetValue(float x, float y, float z)
    {
        Vector.x = x;
        Vector.y = y;
        Vector.z = z;
    }
}
