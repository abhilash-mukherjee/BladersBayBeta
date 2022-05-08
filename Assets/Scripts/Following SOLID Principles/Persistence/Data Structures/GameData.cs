using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public List<Player> players;
    public List<Level> levels;
    public List<Inventory> inventories;
    [SerializeField]private GameState gameState;
    public GameState GameState { get => gameState; set => gameState = value; }
    [SerializeField]
    public GameData()
    {
        players = new List<Player>();
        levels = new List<Level>();
        inventories = new List<Inventory>();
        gameState = new GameState();
    }
}
