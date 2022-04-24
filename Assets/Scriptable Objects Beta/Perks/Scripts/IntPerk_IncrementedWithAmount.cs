using UnityEngine;

[System.Serializable]
public class IntPerk_IncrementedWithAmount : IntPerk
{
    [SerializeField]
    private int incrementAmount;
    public override void Redeem()
    {
        IntVariable.Value += incrementAmount;
    }
}