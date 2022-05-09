using JMRSDK.Toolkit.UI;
using System.Threading.Tasks;
using UnityEngine;

public class FTUEVariableSelection : MonoBehaviour
{
    [SerializeField] public string mainPlayerID = "Player_Main";
    public void SelectAvatar(Sprite avatarSprite)
    {
        var player = GameDataManager.Instance.UnitOfWork.Players.GetByID(mainPlayerID);
        player.PlayerAvatar = avatarSprite;
        GameDataManager.Instance.UnitOfWork.Save();
    }

    public void SelectName(JMRUIPrimaryInputField text)
    {
        var player = GameDataManager.Instance.UnitOfWork.Players.GetByID(mainPlayerID);
        player.PlayerName = text.Text;
        GameDataManager.Instance.UnitOfWork.Save();
    }
}
