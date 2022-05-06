using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public abstract class DataContext : MonoBehaviour
{
    public GameData data;
    public GameData Data
    {
        get => data;
    }
    public abstract Task Load();
    public abstract Task Save();
    public List<T> Set<T>()
    {
        if (typeof(T) == typeof(Player)) return Data.players as List<T>;
        return null;
    }
}
