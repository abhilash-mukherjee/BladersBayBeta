using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateModesUI_SD : MonoBehaviour
 {
    [SerializeField]
    private Image fillImage;
    [SerializeField]
    private FloatVariable floatVariable;
    [SerializeField]
    private float maxValueForField;
 
    private void Update()
    {
        fillImage.fillAmount = floatVariable.Value / maxValueForField;
    }
}
