public interface IPerk
{
    public PerkType PerkType();
    public int PerkCount { get; }
    public void Redeem();
}

