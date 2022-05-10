using UnityEngine.UI;
using UnityEngine;

public class TrainingSceneLevel: MonoBehaviour
{
    [SerializeField]
    private int TrainingNumber;
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
        if (GameDataManager.Instance.UnitOfWork.DataContext.Data.GameState.MaximumTrainingUnlocked < TrainingNumber)
        {
            button.interactable = false;
            lockIcon.SetActive(true);
            buttonImage.color = inActiveColour;
        }
        else
        {
            button.interactable = true;
            lockIcon.SetActive(false);
            buttonImage.color = activeColour;
        }
    }
}
