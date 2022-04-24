using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModeChangeDisplayManager : MonoBehaviour
{
    public delegate void ModeListUpdateHandler(List<ModeNameHolder_SD> _ActiveModeList);
    public static event ModeListUpdateHandler OnActiveModeListUpdated;
    public delegate void LeftRightClickHandler();
    public static event LeftRightClickHandler OnLeftRightClicked;
    // Start is called before the first frame update
    int count = 0;
    [SerializeField]
    private List<ModeNameHolder_SD> initialModeList;
    private List<ModeNameHolder_SD> activeModeList = new List<ModeNameHolder_SD>();
    private BeyBladeStateName m_activeModeName;

    public BeyBladeStateName ActiveModeName { get => m_activeModeName;  }

    private void OnEnable()
    {
        PerkButtonClickManagerForModePerks.OnNewModeActivated += UpdateActiveModeList;
    }
    private void OnDisable()
    {
        PerkButtonClickManagerForModePerks.OnNewModeActivated -= UpdateActiveModeList;
        
    }
    void Start()
    {
        if (initialModeList.Count == 0)
        {
            Debug.LogError("ModesList does not have any entries");
            return;
        }
        UpdateActiveModeList();
        m_activeModeName = activeModeList[0].modeName;
    }

    private void UpdateActiveModeList()
    {
        if(initialModeList.Count == 0)
        {
            Debug.LogError("ModesList does not have any entries");
            return;
        }
        foreach (var _modeObject in initialModeList)
        {
            if (!activeModeList.Contains(_modeObject))
            {
                if (_modeObject.isModeLocked.Value == false)
                {
                    activeModeList.Add(_modeObject);
                }
            }
            else
            {
                if (_modeObject.isModeLocked.Value == true)
                {
                    Debug.Log($"{_modeObject.modeName} is locked so, removed from active list");
                    activeModeList.Remove(_modeObject);
                }
            }
        }
        m_activeModeName = activeModeList[0].modeName;
        OnActiveModeListUpdated?.Invoke(activeModeList);
    }

    public void RightClick(){
        Debug.Log(count);
        foreach(var mode in activeModeList){
            mode.gameObject.SetActive(false);
        }
        count = (count+1) % (activeModeList.Count);
        activeModeList[count].gameObject.SetActive(true);
        m_activeModeName = activeModeList[count].modeName;
        OnLeftRightClicked?.Invoke();
    }

    public void LeftClick()
    {
        foreach(var mode in activeModeList){
            mode.gameObject.SetActive(false);
        }
        if(count <= 0){
            count = activeModeList.Count -1;
        }
        else{
            count --;
        }

        activeModeList[count].gameObject.SetActive(true);
        m_activeModeName = activeModeList[count].modeName;
        OnLeftRightClicked?.Invoke();
    }

}
