using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public abstract class DataContext : MonoBehaviour
{
    [SerializeField]private GameData data;
    public GameData Data
    {
        get => data;
        protected set
        {
            data = value;
        }
    }
    public abstract Task Load();
    public abstract Task Save();
    public List<T> Set<T>()
    {
        if (typeof(T) == typeof(Player)) return Data.players as List<T>;
        if (typeof(T) == typeof(Level)) return Data.levels as List<T>;
        if (typeof(T) == typeof(Inventory)) return Data.inventories as List<T>;
        return null;
    }
}
