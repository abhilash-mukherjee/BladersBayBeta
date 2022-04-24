using UnityEngine;
[CreateAssetMenu(fileName ="New Level Data", menuName = "Data/ Level Data" )]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int levelIndex;
    [SerializeField]
    private bool isLevelVisited = false;
    public int LevelIndex { get => levelIndex;}
    public bool IsLevelVisited { get => isLevelVisited;}

    public void MarkLevelAsVisited()
    {
        isLevelVisited = true;
    }
}
