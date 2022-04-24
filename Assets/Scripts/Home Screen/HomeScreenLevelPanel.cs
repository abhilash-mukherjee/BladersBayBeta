using System.Collections.Generic;
using UnityEngine;

public class HomeScreenLevelPanel : HomeScreenScalable
{
    [SerializeField]
    private List<UILevelData> levelDataList = new List<UILevelData>();
    [SerializeField]
    private IntVariable currentHighestLevel;
    public override void Activate()
    {
        base.Activate();
        FillLevels();
    }
    public override void DeActivate()
    {
        base.DeActivate();
    }

    private void FillLevels()
    {
        foreach (var _level in levelDataList)
        {
            if (_level.LevelData.LevelIndex > currentHighestLevel.Value)
            {
                _level.FillAtOnce(0f, 0f);
                _level.LockOrUnlockLevel(true);
            }
            else if (_level.LevelData.LevelIndex == currentHighestLevel.Value)
            {
                _level.LockOrUnlockLevel(true);
                _level.FillWithAnimation(1f, 1f);
            }
            else
            {
                _level.LockOrUnlockLevel(true);
                _level.FillAtOnce(1f, 1f);
            }
        }
    }
}