using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Holder", menuName = "Stats / Dash / Dash Data")]
public class DashData : ScriptableObject
{
    [SerializeField]
    private float m_dashControlDecreaseRate;
    [SerializeField]
    private float m_dashSpeedDecayRate;
    [SerializeField]
    private float m_dashTime;
    [SerializeField]
    private float m_dashSpeed;
    [SerializeField]
    private float m_dashRechargeRate;
    [SerializeField]
    private float m_dashMaxControl;
    [SerializeField]
    private float m_dashControlReductionTime;

    public float DashControlDecreaseRate { get => m_dashControlDecreaseRate;  }
    public float DashSpeedDecayRate { get => m_dashSpeedDecayRate;  }
    public float DashTime { get => m_dashTime; }
    public float DashSpeed { get => m_dashSpeed; }
    public float DashRechargeRate { get => m_dashRechargeRate; }
    public float DashMaxControl { get => m_dashMaxControl; }
    public float DashControlReductionTime { get => m_dashControlReductionTime; }
}
