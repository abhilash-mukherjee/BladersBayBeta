using JMRSDK.Toolkit.UI;
using UnityEngine;

public class FTUEVariableSelection : MonoBehaviour
{
    public void SelectAvatar(Sprite avatarSprite)
    {
        GameDataManager.Instance.PlayerData.PlayerAvatar = avatarSprite;
    }

    public void SelectName(JMRUIPrimaryInputField text)
    {
        Debug.Log(text.Text);
        GameDataManager.Instance.PlayerData.PlayerName = text.Text;
    }
}
