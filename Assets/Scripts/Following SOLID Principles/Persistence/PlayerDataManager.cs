using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField]
    private string playerID = "Player_Main";
    [SerializeField]
    private BeyBladeData playerData;
    [SerializeField]
    private Player initialPlayerData;
    [SerializeField]
    private UnitOfWork unitOfWork;
    private void OnEnable()
    {
        Player.OnPlayerDataChanged += OnPlayerDataChanged;     
    }
    private void OnDisable()
    {
        Player.OnPlayerDataChanged -= OnPlayerDataChanged;     
    }
    public void StartLoad()
    {
        var _player = unitOfWork.Players.GetByID(playerID);
        if (_player == null)
        {
            var _newPlayer = new Player(initialPlayerData);
            Debug.Log(_newPlayer.ID + " Added");
            unitOfWork.Players.Add(_newPlayer);
            playerData.SetFromSerializableData(_newPlayer);
            unitOfWork.Save();
        }
        else
        {
            playerData.SetFromSerializableData(_player);
            unitOfWork.Save();
        }
    }
    public void OnPlayerDataChanged(string _id)
    {
        if (_id != playerID) return;
        var _player = unitOfWork.Players.GetByID(playerID);
        Debug.Log($"Player data = {_player.ModelName}, {_player.PlayerName}, {_player.GetBeyBladeIcon()}, {_player.GetAvatar()}, {_player.ModelName}");
        playerData.SetFromSerializableData(_player);
    }
}
