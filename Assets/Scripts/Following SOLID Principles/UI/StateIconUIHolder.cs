using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateIconUIHolder : MonoBehaviour
{
    [SerializeField]
    private BeyBladeStateName beyBladeStateName;
    [SerializeField]
    private AbilityData AbilityData;
    [SerializeField]
    private Image loader;
    [SerializeField]
    private List<Image> ImageList;
    [SerializeField]
    private GameObject transitionEffect;
    [SerializeField]
    private string boolName;
    [SerializeField]
    [Range(0f, 10f)]
    private float coroutineTime;
    [SerializeField]
    private Color inActiveColor, activeColor;
    [SerializeField]
    private float maxAvailabilityIndex;
    private bool isCharged = false;
    private bool isCoroutineCalled = false;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioEvent abilityActivationAudioEvent;
    private Animator transitionAnimator;

    private void Update()
    {
        DisplayUI();
    }

    private void OnEnable()
    {
        if (AbilityData.IsAbilityLocked)
            gameObject.SetActive(false);
        transitionAnimator = transitionEffect.GetComponent<Animator>();
    }
    public void DisplayUI()
    {
        if (AbilityData.AvailabilityIndex / maxAvailabilityIndex >= 1f)
        {
            loader.fillAmount = 1f;
            if (isCoroutineCalled || isCharged)
                return;
            isCharged = true;
            isCoroutineCalled = true;
            abilityActivationAudioEvent.Play(audioSource);
            transitionEffect.SetActive(true);
            Debug.Log("entered coroutine");
            foreach(var i in ImageList)i.color = activeColor;
            StartCoroutine(TransitionEffect());
        }
        else
        {
            isCharged = false;
            loader.fillAmount = AbilityData.AvailabilityIndex / maxAvailabilityIndex;
            foreach (var i in ImageList) i.color = inActiveColor;
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

