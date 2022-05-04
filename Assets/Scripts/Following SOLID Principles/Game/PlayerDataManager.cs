using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField]
    private BeyBladeData playerData;
    private void OnEnable()
    {
        SerializablePlayerData.OnPlayerDataChanged += UpdatePlayerData;
    }
    private void OnDisable()
    {
        SerializablePlayerData.OnPlayerDataChanged -= UpdatePlayerData;
    }

    private void Start()
    {
        UpdatePlayerData();
    }
    public void UpdatePlayerData()
    {
        playerData.SetFromSerializableData(GameDataManager.Instance.PlayerData);
    }
}