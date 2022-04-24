using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Float Variable", menuName = "Variables/ranged float 0 to 1")]
public class RangedFloatVariable_0_1 : FloatVariable
{
    [SerializeField][Range(0f,1f)]
    private float rangedFloatValue;
    public override float Value { get => rangedFloatValue; set => this.rangedFloatValue = value; }
}
