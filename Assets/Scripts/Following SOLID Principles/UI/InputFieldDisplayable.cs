using JMRSDK.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldDisplayable : PanelDisplayable
{
    [SerializeField]
    private JMRUIPrimaryInputField inputField;
    [SerializeField]
    private Image image;
    [SerializeField]
    private BeyBladeData playerData;
    private string m_name;
    public override void EnterForward()
    {
        image.sprite = playerData.PlayerAvatar;
        base.EnterForward();
    }
    public override void EnterReverse()
    {
        base.EnterReverse();
    }
    public override void ExitForward()
    {
        m_name = inputField.Text;
        GameDataManager.Instance.PlayerData.PlayerName = m_name;
        base.ExitForward();
    }
}
