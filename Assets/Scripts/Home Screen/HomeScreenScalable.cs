using UnityEngine;

public class HomeScreenScalable : HomeScreenElement
{
    [SerializeField]
    private float popUpAnimationTime = 0.5f;
    [SerializeField]
    private Vector3 activatedLocalScale, deActivatedLocalScale;
    private Vector3 m_TargetScale;
    private float m_timeElapsed;
    private void Awake()
    {
        m_timeElapsed = popUpAnimationTime;
    }
    void Update()
    {
        LerpScale();
    }

    private void LerpScale()
    {
        if (m_timeElapsed < popUpAnimationTime)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, m_TargetScale, m_timeElapsed / popUpAnimationTime);
            m_timeElapsed += Time.deltaTime;
        }
    }
    public override void Activate()
    {
        m_TargetScale = activatedLocalScale;
        m_timeElapsed = 0f;
    }
    public override void DeActivate()
    {
        m_TargetScale = deActivatedLocalScale;
        m_timeElapsed = 0f;
    }
}
