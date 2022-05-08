using UnityEngine;

public class UnitOfWork : MonoBehaviour
{
    [SerializeField] private Players players;
    [SerializeField] private Levels levels;
    [SerializeField] private Inventories inventories;
    [SerializeField] private DataContext dataContext;

    public Players Players { get => players; set => players = value; }
    public Levels Levels { get => levels; set => levels = value; }
    public Inventories Inventories { get => inventories; set => inventories = value; }

    public async void Save() => await dataContext.Save();
}

















