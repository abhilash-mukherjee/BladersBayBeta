using UnityEngine.UI;
using UnityEngine;

public class LevelSceneLevel: MonoBehaviour
{
    [SerializeField]
    private int LevelNumber;
    [SerializeField]
    private Color activeColour, inActiveColour;
    [SerializeField]
    private GameObject lockIcon;
    [SerializeField]
    private Image buttonImage;
    [SerializeField] private JMRSDK.Toolkit.JMRUIPrimaryButton button;

    private void OnEnable()
    {
        OnDataLoaded();
    }
    public void OnDataLoaded()
    {
        if (GameDataManager.Instance.UnitOfWork.DataContext.Data.GameState.MaximumLevelUnlocked < LevelNumber)
        {
            button.interactable = false;
            if(lockIcon!= null)lockIcon.SetActive(true);
            buttonImage.color = inActiveColour;
        }
        else
        {
            button.interactable = true;
            if (lockIcon != null) lockIcon.SetActive(false);
            buttonImage.color = activeColour;
        }
    }
}