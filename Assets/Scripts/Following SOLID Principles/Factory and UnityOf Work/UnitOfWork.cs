using UnityEngine;

public class UnitOfWork : MonoBehaviour
{
    [SerializeField] private Players players;
    [SerializeField] private DataContext dataContext;

    public Players Players { get => players; set => players = value; }

    public async void Save() => await dataContext.Save();
}

















