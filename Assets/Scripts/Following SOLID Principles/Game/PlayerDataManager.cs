using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField]
    private string playerID = "Player_Main";
    [SerializeField]
    private BeyBladeData playerData;
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
            var _newPlayer = new Player(playerData);
            _newPlayer.id = playerID;
            Debug.Log(_newPlayer.id + " Added");
            unitOfWork.Players.Add(_newPlayer);
        }
        else
        {
            playerData.SetFromSerializableData(_player);
        }
    }
    public void OnPlayerDataChanged(string _id)
    {
        if (_id != playerID) return;
        var _player = unitOfWork.Players.GetByID(playerID);
        playerData.SetFromSerializableData(_player);
    }
}