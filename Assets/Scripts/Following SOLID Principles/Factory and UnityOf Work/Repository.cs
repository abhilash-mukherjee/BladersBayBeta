using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
[System.Serializable]
public abstract class Repository<T> : MonoBehaviour where T : Base
{
    public DataContext context;
    private List<T> Entities => context.Set<T>();
    public T GetByID(string _id)
    {
        return Entities.FirstOrDefault(e => e.id == _id);
    }

    public void Add(T _entity)
    {
        Entities.Add(_entity);
        Debug.Log("Inside repository. Length of List = " + Entities.Count);
        Debug.Log($"Length og player list of context.data = {context.Data.players.Count}");
        StartCoroutine(DebugStatement());
    }
    IEnumerator DebugStatement()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log($"Length og player list of context.data = {context.Data.players.Count}");
    }
    public void Delete(T _entity) => Entities.Remove(_entity);
    public void Modify(T _entity)
    {
        int i = Entities.FindIndex(e => e.id == _entity.id);
        Entities[i] = _entity;
    }

}

















