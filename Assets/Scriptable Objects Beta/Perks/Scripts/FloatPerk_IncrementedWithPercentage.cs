using UnityEngine;

[System.Serializable]
public class FloatPerk_IncrementedWithPercentage : FloatPerk
{
    [SerializeField][Range(0,1)]
    protected float incrementPercentage;
    public override void Redeem()
    {
        FloatVariable.Value = (1 + incrementPercentage) * FloatVariable.Value;
    }
}
