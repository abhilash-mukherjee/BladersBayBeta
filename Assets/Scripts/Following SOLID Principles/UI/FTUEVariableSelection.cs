using JMRSDK.Toolkit.UI;
using System.Threading.Tasks;
using UnityEngine;

public class FTUEVariableSelection : MonoBehaviour
{
    [SerializeField]
    private UnitOfWork unitOfWork;
    [SerializeField] public string mainPlayerID = "Player_Main";
    public void SelectAvatar(Sprite avatarSprite)
    {
        var player = unitOfWork.Players.GetByID(mainPlayerID);
        player.PlayerAvatar = avatarSprite;
        unitOfWork.Save();
    }

    public void SelectName(JMRUIPrimaryInputField text)
    {
        var player = unitOfWork.Players.GetByID(mainPlayerID);
        player.PlayerName = text.Text;
        unitOfWork.Save();
    }
}
