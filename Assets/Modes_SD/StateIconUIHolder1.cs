using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateIconUIHolder1 : MonoBehaviour
{
    [SerializeField]
    private BeyBladeStateName beyBladeStateName;
    [SerializeField]
    private StateData StateData;
    [SerializeField]
    private Image loader;
    [SerializeField]
    private Image logo;
    [SerializeField]
    private GameObject transitionEffect;
    [SerializeField]
    private string boolName;
    [SerializeField]
    [Range(0f, 10f)]
    private float coroutineTime;
    [SerializeField]
    private Color inActiveColor, activeColor;
    private bool isCharged = false;
    private bool isCoroutineCalled = false;
    [SerializeField]
    private string electricitySoundName;
    private Animator transitionAnimator;

    private void Update()
    {
        DisplayUI();
    }

    private void OnEnable()
    {
        if (StateData.IsLocked)
            gameObject.SetActive(false);
        StateData.CurrentAvailabilityIndex = 0f;
        transitionAnimator = transitionEffect.GetComponent<Animator>();
    }
    public void DisplayUI()
    {
        if (StateData.CurrentAvailabilityIndex / StateData.ThresholdStateAvailabiltyIndex  >= 1f)
        {
            loader.fillAmount = 1f;
            if (isCoroutineCalled || isCharged)
                return;
            isCharged = true;
            isCoroutineCalled = true;
            GameAudioManager.Instance.PlaySoundOneShot(electricitySoundName);
            transitionEffect.SetActive(true);
            Debug.Log("entered coroutine");
            logo.GetComponent<Image>().color = activeColor;
            StartCoroutine(TransitionEffect());
        }
        else
        {   
            isCharged = false;
            loader.fillAmount = StateData.CurrentAvailabilityIndex / StateData.ThresholdStateAvailabiltyIndex;
            logo.GetComponent<Image>().color = inActiveColor;
        }
    }

    IEnumerator TransitionEffect()
    {
        transitionAnimator.SetBool(boolName, true);
        yield return new WaitForSeconds(coroutineTime);
        transitionEffect.SetActive(false);
        isCoroutineCalled = false;
        transitionAnimator.SetBool(boolName, false);
    }
}
