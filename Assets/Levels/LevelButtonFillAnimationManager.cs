using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonFillAnimationManager : MonoBehaviour
{
    public List<LevelFillDataHolder> levelNumberChild;
    public List<LevelFillDataHolder> connectingChild;
    [SerializeField]
    private PlayerData PlayerData;
    [SerializeField]
    private float animationSpeedMultiplier = 1f;
    [SerializeField]
    private float animationStartTime = 1f;
    float timeElapsed = 0;
    bool shouldFill = false;
    public int index = 1;
    

    public void StartLevelFillAnimation()
    {
        var _maxLevel = PlayerData.MaximumLevelUnlocked.Value;
        for (int i = 1; i < _maxLevel; i++)
        {
            levelNumberChild[i-1].displayUI.fillAmount = 1f;
            levelNumberChild[i-1].centerUI.gameObject.SetActive(true);
            levelNumberChild[i-1].lockIcon.SetActive(false);
            // levelNumberChild[i-1].displayText.color = new Color()
            if (i != 1)
                connectingChild[i - 2].displayUI.fillAmount = 1f;
        }
        if (_maxLevel == 1)
        {
            StartCoroutine(StartFillingStrokeAfterPause());
        }
        else
        {
            StartCoroutine(StartFillingConnectingLineAfterPause(_maxLevel - 2));
        }
    }

    IEnumerator StartFillingStrokeAfterPause()
    {
        yield return new WaitForSeconds(animationStartTime);
        StartCoroutine(FillStroke(0));
    }
    
    IEnumerator StartFillingConnectingLineAfterPause(int _index)
    {
        yield return new WaitForSeconds(animationStartTime);
        StartCoroutine(FillConnectingStroke(_index));
    }
    IEnumerator FillStroke(int index)
    {
        levelNumberChild[index].lockIcon.SetActive(false);
        float timeElapsed = levelNumberChild[index].timeElapsed;
        while (levelNumberChild[index].displayUI.fillAmount < 1f)
        {
            levelNumberChild[index].displayUI.fillAmount = levelNumberChild[index].timeElapsed;
            levelNumberChild[index].timeElapsed += Time.deltaTime * animationSpeedMultiplier;
            yield return null;
        }

        levelNumberChild[index].centerUI.gameObject.SetActive(true);

        levelNumberChild[index].isFilled = true;
        levelNumberChild[index].timeElapsed = 0f;

    }

    IEnumerator FillConnectingStroke(int index)
    {
        Debug.Log(index);
        while (connectingChild[index].displayUI.fillAmount < 1f)
        {
            connectingChild[index].displayUI.fillAmount = connectingChild[index].timeElapsed;
            connectingChild[index].timeElapsed += Time.deltaTime * animationSpeedMultiplier;
            yield return null;
        }

        connectingChild[index].isFilled = true;
        connectingChild[index].timeElapsed = 0f;
        StartCoroutine(FillStroke(index + 1));
    }
}
