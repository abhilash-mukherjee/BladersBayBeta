using UnityEngine;

[System.Serializable]
public class BooleanPerk : Perk
{
    [SerializeField]
    private BoolVariable BoolVariable;
    [SerializeField]
    private bool finalBool;
    public override void Redeem()
    {
        BoolVariable.Value = finalBool;
    }
}
