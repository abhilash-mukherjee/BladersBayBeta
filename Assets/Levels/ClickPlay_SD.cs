using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPlay_SD : MonoBehaviour
{
    public List<UIElementsPopupManager > levelsUINew_SDs;
    [SerializeField]
    private bool isPlayClick = true;
    [SerializeField]
    private GameObject infoButton;
    [SerializeField]
    private LevelButtonFillAnimationManager LevelButtonFillAnimationManager;
    public void StartUIPopUpPopDown(bool isReversed){
        isPlayClick = !isPlayClick;
        infoButton.SetActive(isPlayClick);
        LevelButtonFillAnimationManager.StartLevelFillAnimation();
        foreach(var levelsUINew_SD in levelsUINew_SDs){
            levelsUINew_SD.AnimateUIStart(isReversed);
        }
    }
}
