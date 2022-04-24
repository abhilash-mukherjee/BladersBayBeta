using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDisplayManager : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private BeyBladeData beybladeData;


    void Start(){
        icon.sprite = beybladeData.icon;
    }

}
