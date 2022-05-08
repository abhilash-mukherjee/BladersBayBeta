using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class JsonDataContext : DataContext
{
    public string filename;
    private void Awake()
    {
        Data = new GameData();
    }

    private void Start()
    {
        StartCoroutine(DebugStatement());
    }
    IEnumerator DebugStatement()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log(Data.players.Count);

    }
    public override async Task Load()
    {
        var fullPath = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(fullPath)) return;
        using var reader = new StreamReader(fullPath);
        var json = await reader.ReadToEndAsync();
        JsonUtility.FromJsonOverwrite(json, Data);
    }

    public override async Task Save()
    {
        Debug.Log(Data.players.Count);
        var json = JsonUtility.ToJson(Data);
        Debug.Log(json);
        var fullPath = Path.Combine(Application.persistentDataPath, filename);
        using var writer = new StreamWriter(fullPath);
        await writer.WriteAsync(json); 
    }
}



















