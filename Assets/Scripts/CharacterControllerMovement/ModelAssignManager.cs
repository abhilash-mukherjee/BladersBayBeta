using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAssignManager : MonoBehaviour
{
    [SerializeField]
    private BeyBladeData beyBladeData;
    [SerializeField]
    private GameObject ModelParet;
    [SerializeField]
    private Vector3 ModelLocalScale;
    [SerializeField]
    private Vector3 ModelLocalPosition;
    private void OnEnable()
    {
        if (ModelParet.transform.childCount > 0) Destroy(ModelParet.transform.GetChild(0).gameObject);
        var _model = Instantiate(beyBladeData.Model, ModelParet.transform);
        _model.transform.localPosition = ModelLocalPosition;
        _model.transform.localScale = ModelLocalScale;
    }
}
