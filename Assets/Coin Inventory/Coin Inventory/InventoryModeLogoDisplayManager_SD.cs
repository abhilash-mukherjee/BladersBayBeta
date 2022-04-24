using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryModeLogoDisplayManager_SD : MonoBehaviour
{
    [SerializeField]
    private List<ModeNameHolder_SD> modeLogoList = new List<ModeNameHolder_SD>();
    [SerializeField]
    private InventoryModeChangeDisplayManager inventoryModeChangeDisplay;
    [SerializeField]
    private Vector3 activeLocalScale, inActiveLocalScale;
    [SerializeField]
    private Color activeColor, inActiveColor;
    private void OnEnable()
    {
        InventoryModeChangeDisplayManager.OnActiveModeListUpdated += UpdateModeLogoList;
        InventoryModeChangeDisplayManager.OnLeftRightClicked += OnLeftRightClicked;
    }
    private void OnDisable()
    {
        InventoryModeChangeDisplayManager.OnActiveModeListUpdated -= UpdateModeLogoList;
        InventoryModeChangeDisplayManager.OnLeftRightClicked -= OnLeftRightClicked;
        
    }
    private void Start()
    {
        modeLogoList[0].gameObject.transform.localScale = activeLocalScale;
        modeLogoList[0].gameObject.GetComponent<Image>().color = activeColor ;
        if(modeLogoList.Count > 1)
        {
            for (int i = 1; i < modeLogoList.Count; i++)
            {
                modeLogoList[i].gameObject.transform.localScale = inActiveLocalScale;
                modeLogoList[i].gameObject.GetComponent<Image>().color = inActiveColor;
            }
        }
    }

    private void UpdateModeLogoList(List<ModeNameHolder_SD> _ActiveModeList)
    {
        foreach(var _logo in modeLogoList)
        {
            var _activeMode = _ActiveModeList.Find(p => p.modeName == _logo.modeName);
            if (_activeMode == null)
            {
                Debug.Log("Could not find the " + _logo.modeName + " in " + _ActiveModeList.ToString());
                _logo.gameObject.SetActive(false);
            }
            else _logo.gameObject.SetActive(true);
        }
    }

    public void OnLeftRightClicked()
    {
        foreach (var _logo in modeLogoList)
        {
            if(inventoryModeChangeDisplay.ActiveModeName == _logo.modeName)
            {
               _logo.gameObject.transform.localScale = activeLocalScale;
               _logo.gameObject.GetComponent<Image>().color = activeColor;
            }
            else
            {
                _logo.gameObject.transform.localScale = inActiveLocalScale;
                _logo.gameObject.GetComponent<Image>().color = inActiveColor;
            }
        }
    }
}
