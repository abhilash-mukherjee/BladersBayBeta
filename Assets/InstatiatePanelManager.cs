using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiatePanelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Vector3 localScale;

    public void InstatiatePanel(GameObject gameObject){
        GameObject _go = Instantiate(panel,transform.parent);
        // _go.transform.localPosition = transform.position;
        Debug.Log(_go.transform.localPosition);
        _go.transform.localScale = localScale;
        Debug.Log(_go.transform.localScale);
    }
}
