using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinnerDecideManager : MonoBehaviour
{
    public delegate void ResultsDecidedHandler(GameObject _winner, GameObject _looser);
    public delegate void LevelResultsDecidedHandler(GameObject _winner, GameObject _looser, string _levelID);
    public static event ResultsDecidedHandler OnResultsDecided;
    public static event LevelResultsDecidedHandler OnLevelResultsDecided;
    [SerializeField]
    private List<GameObject> BeyBladeList = new List<GameObject>();
    [SerializeField]
    private GameEvent matchEndEvent;
    [SerializeField]
    private string levelID;
    private GameObject m_winner, m_losser;
    public void DetermineWnnerAndLooser(GameObject _gameObject)
    {
        m_losser = _gameObject;
        m_winner = BeyBladeList.Find(p => p != m_losser);
        if (m_winner == null || m_losser == null)
        {
            Debug.LogError("Some error in determining inner and looser. Either of them is unassigned");
        }
        else
        {
            OnResultsDecided?.Invoke(m_winner, m_losser);
            OnLevelResultsDecided?.Invoke(m_winner, m_losser, levelID);
            matchEndEvent.Raise();
        }
    }
}
