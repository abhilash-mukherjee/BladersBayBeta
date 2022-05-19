using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public static GameAssets Instance
    {
        get
        {
            if (_i == null) { _i = Instantiate(Resources.Load("Game Assets") as GameObject).GetComponent<GameAssets>(); }
            return _i;
        }
    }

    [SerializeField]
    private List<AssetMappings<GameObject>> models;
    [SerializeField]
    private List<AssetMappings<Sprite>> avatars, icons;


    public GameObject LoadGameObject(string key)
    {
        var p = models.Find(p => p.assetKey == key);
        if (p != null) return p.asset;
        else return null;
    }
    public Sprite LoadAvatarSprite(string key)
    {
        var p = avatars.Find(p => p.assetKey == key);
        if (p != null) return p.asset;
        else return null;
    }
    public Sprite LoadIconSprite(string key)
    {
        var p = icons.Find(p => p.assetKey == key);
        if (p != null) return p.asset;
        else return null;
    }
}
[System.Serializable]
public class AssetMappings<T>
{
    public string assetKey;
    public T asset;
}