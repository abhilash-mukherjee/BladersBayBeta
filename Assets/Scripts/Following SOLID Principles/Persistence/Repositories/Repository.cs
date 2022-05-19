using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
[System.Serializable]
public abstract class Repository<T> : MonoBehaviour where T : Base
{
    [SerializeField] private DataContext m_Context;
    public DataContext Context
    {
        get => m_Context;
        private set => m_Context = value;
    }
    private List<T> Entities => Context.Set<T>();
    public T GetByID(string _id)
    {
        return Entities.FirstOrDefault(e => e.ID == _id);
    }

    public void Add(T _entity)
    {
        Entities.Add(_entity);
        if (typeof(T) == typeof(Player))
        {
           Debug.Log($"ID = {m_Context.Data.players[0].ID} ,Model =  {m_Context.Data.players[0].GetModel()}, Icon =  {m_Context.Data.players[0].GetBeyBladeIcon()} , Avatar =  {m_Context.Data.players[0].GetAvatar()}");
        }
    }
    IEnumerator DebugStatement()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log($"Length of player list of context.data = {Context.Data.players.Count}");
    }
    public void Delete(T _entity) => Entities.Remove(_entity);
    public void Modify(T _entity)
    {
        int i = Entities.FindIndex(e => e.ID == _entity.ID);
        Entities[i] = _entity;
    }

}

















