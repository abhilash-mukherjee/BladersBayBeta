using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string ACTIVATED, AVAILABLE, SET_INACTIVE;
    [SerializeField]
    private BeyBladeStateName targetModeName;
    [SerializeField]
    private BeyBladeStateAvailabilityEnum ModeAvailable, ModeUnAvailable, ModeActivated; 
    [SerializeField]
    private StateController playerStateController;
    [SerializeField]
    private BeyBladeStateAvailabilityEnum startingAvailabilityStatus;
    private BeyBladeStateAvailabilityEnum m_currentAvailabilityStatus;
    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += CheckIfWonOrLost;
        m_currentAvailabilityStatus = startingAvailabilityStatus;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= CheckIfWonOrLost;
    }

    private void CheckIfWonOrLost(GameObject _winner, GameObject _looser)
    {
        gameObject.SetActive(false);
    }
    public void PlaySound(string _soundName)
    {
        GameAudioManager.Instance.PlaySoundOneShot(_soundName);
    }
    private void Update()
    {
        Debug.Log(m_currentAvailabilityStatus);
        Debug.Log(playerStateController);
        Debug.Log(playerStateController.StateDict.ToString());
        if (m_currentAvailabilityStatus == playerStateController.StateDict[targetModeName].AvailabilityStatus.Name)
        {
            return;
        }
        
        if (playerStateController.StateDict[targetModeName].AvailabilityStatus.Name == ModeAvailable)
        {
            animator.SetBool(AVAILABLE, true);
            animator.SetBool(ACTIVATED, false);
            animator.SetBool(SET_INACTIVE, false);
            m_currentAvailabilityStatus = ModeAvailable;
        }

        else if (playerStateController.CurrentState.Name == targetModeName)
        {
            animator.SetBool(AVAILABLE, false);
            animator.SetBool(ACTIVATED, true);
            animator.SetBool(SET_INACTIVE, false);
            m_currentAvailabilityStatus = ModeActivated;


        }
        else if (playerStateController.StateDict[targetModeName].AvailabilityStatus.Name == ModeUnAvailable)
        {
            animator.SetBool(AVAILABLE, false);
            animator.SetBool(ACTIVATED, false);
            animator.SetBool(SET_INACTIVE, true);
            m_currentAvailabilityStatus = ModeUnAvailable;
        }
    }
}
