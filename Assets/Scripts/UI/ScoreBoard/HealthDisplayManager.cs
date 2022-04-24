using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Image healthSprite;
    [SerializeField]
    FloatReference maxHealth;
    [SerializeField]
    FloatVariable currentHealth;
    private float m_targetFill = 1f;
    private void UpdateHealth()
    {
        m_targetFill = currentHealth.Value / maxHealth.Value;
        healthSprite.fillAmount = m_targetFill;

    }
    private void Update()
    {
        UpdateHealth();
        
    }
  
}
