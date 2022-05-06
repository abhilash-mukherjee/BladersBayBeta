using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public List<Player> players;

    public GameData()
    {
        players = new List<Player>();
    }
}
