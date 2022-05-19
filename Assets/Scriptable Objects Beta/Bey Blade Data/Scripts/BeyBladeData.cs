using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New BeyBlade Data", menuName = "Data / Bey Blade Data")]
public class BeyBladeData : ScriptableObject
{
    public delegate void PlayerDataChangeHandler();
    public static event PlayerDataChangeHandler OnPlayerDataChanged;
    public AbilityData attackData, defenceData, staminaData, balanceData;
    [SerializeField]
    private string playerName;
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private Sprite playerAvatar;
    [SerializeField]
    private string modelName;

    public string PlayerName { get => playerName; set => playerName = value; }
    public GameObject Model { get => model; set => model = value; }
    public Sprite Icon { get => icon; set => icon = value; }
    public Sprite PlayerAvatar { get => playerAvatar; set => playerAvatar = value; }
    public string ModelName { get => modelName; set => modelName = value; }

    public void SetFromSerializableData(Player _playerData)
    {
        Debug.Log("Data getting set");
        modelName = _playerData.ModelName;
        playerName = _playerData.PlayerName;
        model = _playerData.GetModel();
        icon = _playerData.GetBeyBladeIcon();
        playerAvatar = _playerData.GetAvatar();
    }
}
 