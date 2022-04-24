using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelFillDataHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Image displayUI,centerUI;
    public TextMeshProUGUI displayText;
    public bool isFilled = false;
    public float timeElapsed = 0f;
    public GameObject lockIcon;
}
