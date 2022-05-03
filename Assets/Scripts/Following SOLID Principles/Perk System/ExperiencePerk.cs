public class ExperiencePerk : IPerk
{
    public delegate void ExperienceAddHandler(int _Count);
    public static event ExperienceAddHandler OnExperienceAdded;
    private int m_experienceToAdd;
    private PerkType m_perkType;

    public int PerkCount { get => m_experienceToAdd;  }

    public ExperiencePerk(int experienceGained, PerkType perkType)
    {
        m_experienceToAdd = experienceGained;
        m_perkType = perkType;
    }
    public void Redeem()
    {
        OnExperienceAdded?.Invoke(m_experienceToAdd);
    }

    public PerkType PerkType()
    {
        return m_perkType;
    }
}
