using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level Data Holde", menuName = "Data/ Level Data Holder" )]
public class LevelDataHolder : ScriptableObject
{
    [SerializeField]
    private List<LevelData> levelDataList = new List<LevelData>();

    public List<LevelData> LevelDataList { get => levelDataList; }
}
