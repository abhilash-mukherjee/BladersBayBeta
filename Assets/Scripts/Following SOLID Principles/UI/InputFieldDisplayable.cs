using JMRSDK.Toolkit.UI;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldDisplayable : PanelDisplayable
{
    [SerializeField]
    private JMRUIPrimaryInputField inputField;
    [SerializeField]
    private Image image;
    [SerializeField]
    private UnitOfWork unitOfWork;
    [SerializeField]
    private string playerID = "Player_Main";
    private string m_name;
    public override void EnterForward()
    {
        image.sprite = unitOfWork.Players.GetByID(playerID).PlayerAvatar;
        base.EnterForward();
    }
    public override void EnterReverse()
    {
        base.EnterReverse();
    }
    public override void ExitForward()
    {
        if (inputField.Text == "") m_name = "Player"; 
        else m_name = inputField.Text;
        var player = unitOfWork.Players.GetByID(playerID);
        player.PlayerName = m_name;
        base.ExitForward();
        StartCoroutine(SaveCoroutine());
    }
    IEnumerator SaveCoroutine()
    {
        Save();
        yield return null;
    }
    private void Save()
    {
        unitOfWork.Save();
    }
}
