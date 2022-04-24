using UnityEngine;

[System.Serializable]
public class FloatPerk_IncrementedWithAmount : FloatPerk
{
    [SerializeField][Range(0,1)]
    protected float incrementAmount;
    public override void Redeem()
    {
        FloatVariable.Value += incrementAmount ;
    }
}
