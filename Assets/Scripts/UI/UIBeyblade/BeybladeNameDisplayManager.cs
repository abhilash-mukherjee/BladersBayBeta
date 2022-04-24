using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BeybladeNameDisplayManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private BeyBladeData beyBladeData;
    void Start()
    {
        text.text = beyBladeData.ModelName;
    }
}
