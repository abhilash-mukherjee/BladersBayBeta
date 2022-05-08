public class ExperiencePerk : IPerk
{
    public delegate void ExperienceAddHandler(int _Count, string _RecieverID);
    public static event ExperienceAddHandler OnExperienceAdded;
    private int m_experienceToAdd;
    private bool m_isRedeemed;
    private PerkType m_perkType;
    private string m_recieverID;
    public int PerkCount { get => m_experienceToAdd;  }

    public string Reciever { get => m_recieverID; }

    public ExperiencePerk(int experienceGained, PerkType perkType, string _recieverID)
    {
        m_experienceToAdd = experienceGained;
        m_perkType = perkType;
        m_recieverID = _recieverID;
        m_isRedeemed = false;
    }
    public void Redeem()
    {
        OnExperienceAdded?.Invoke(m_experienceToAdd, m_recieverID);
        m_experienceToAdd = 0;
        m_isRedeemed = true;
    }

    public PerkType PerkType()
    {
        return m_perkType;
    }
}
