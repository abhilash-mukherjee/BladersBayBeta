using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnmationLeftRight_SD : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    GameObject left,right;
    [SerializeField]
    private Vector3 leftInitialPos = new Vector3(-1866f, 0, 0), leftFinalPos = new Vector3(-134.67f, 0, 0), rightInitialPos = new Vector3(2024f, 0, 0), RightFinalPos = new Vector3(292.67f, 0, 0);
    [SerializeField]
    private float rate = 0;
    [SerializeField]
    private float distLimit = 0.01f;
    private bool m_startAnim = false, m_endAnim = false;
    private void Start()
    {
        left.transform.localPosition = leftInitialPos;
        right.transform.localPosition = rightInitialPos;
    }
    public void StartAnimationAfterEventRecieved(float _time)
    {
        StartCoroutine(CallStartPanelAnim(_time));
    }
    IEnumerator CallStartPanelAnim(float _time)
    {
        yield return new WaitForSeconds(_time);
        StartPanelAnim();
    }
    private void StartPanelAnim()
    {
        m_startAnim = true;
    }
    void Update() 
    {
        if (m_startAnim == false && m_endAnim == true)
            return;
        var _ld = Vector3.Distance(left.transform.position, leftFinalPos);
        var _rd = Vector3.Distance(right.transform.position, RightFinalPos);
        if(_ld <= distLimit && _rd <= distLimit)
        {
            m_endAnim = true;
            return;
        }
        left.transform.localPosition = Vector3.Lerp(left.transform.localPosition,leftFinalPos,rate);
        right.transform.localPosition = Vector3.Lerp(right.transform.localPosition,RightFinalPos,rate);
    }

}
