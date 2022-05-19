using BayatGames.SaveGameFree;
using UnityEngine;
using System.Threading.Tasks;
public class SaveGameDataContext : DataContext
{
    [UnityEngine.SerializeField] private string identifier;
    private bool m_isSaving = false;
    private bool m_isLoading = false;

    public override async Task Load()
    {
        m_isLoading = true;
        while (m_isSaving)
        {
            Debug.Log("still saving");
            await Task.Yield();
        }
        Data = SaveGame.Load(identifier, Data);
        m_isLoading = false;
        if (Data.players.Count > 0)
        {
            var p = Data.players[0];
            Debug.Log($"loaded from saveGameasset. Data = {p.ModelName},{p.GetModel()}, {p.GetAvatar()}, {p.GetBeyBladeIcon()}");
        }
    }

    public override async Task Save()
    {
        m_isSaving = true;
        while (m_isLoading)
        {
            Debug.Log("still loading");
            await Task.Yield();
        }
        SaveGame.Save(identifier, Data);
        m_isSaving = false;
        var p = Data.players[0];
        Debug.Log($"Saving Data = {p.ModelName},{p.GetModel()}, {p.GetAvatar()}, {p.GetBeyBladeIcon()}");
    }
}



















