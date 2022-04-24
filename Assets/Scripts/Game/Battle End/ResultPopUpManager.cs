using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPopUpManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player, winMessege, looseMessege, levelRepeatWinMessege;
    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private List<GameObject> objectsToDisable = new List<GameObject>();
    private bool m_hasPlayerWon = false;
    private bool m_isLevelVisited = false;
    private void Awake()
    {
        m_isLevelVisited = levelData.IsLevelVisited;
    }
    private void OnEnable()
    {
        WinnerDecideManager.OnResultsDecided += CheckIfWonOrLost;
        ParabolaController.OnParabolaReachedDestination += PopUpMessege;
    }
    private void OnDisable()
    {
        WinnerDecideManager.OnResultsDecided -= CheckIfWonOrLost;
        ParabolaController.OnParabolaReachedDestination -= PopUpMessege;
    }

    private void PopUpMessege()
    {
        foreach (var _gO in objectsToDisable)
        {
            _gO.SetActive(false);
        }
        if (m_hasPlayerWon)
        {
            if (m_isLevelVisited)
                levelRepeatWinMessege.SetActive(true);
            else 
                winMessege.SetActive(true);
        }
        else looseMessege.SetActive(true);
    }

    private void CheckIfWonOrLost(GameObject _winner, GameObject _looser)
    {
        if (_winner == player) m_hasPlayerWon = true;
        else m_hasPlayerWon = false;
    }
    
}
