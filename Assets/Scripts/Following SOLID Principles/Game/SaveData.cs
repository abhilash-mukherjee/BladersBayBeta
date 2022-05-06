[System.Serializable]
public class SaveData
{
    public int coinCount;
    public Player playerData;
    public int CoinCount { get => coinCount; set => coinCount = value; }
    public Player PlayerData { get => playerData; set => playerData = value; }
}
public interface ISavable
{
    public void LoadFromSaveData(SaveData _sd);
    public void PopulateSaveData(SaveData _sd);
}

