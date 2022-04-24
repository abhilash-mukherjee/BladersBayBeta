using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]
public class PanelDisplayManager : MonoBehaviour, IDisplayable
{
    [SerializeField]
    private float panelDisappearTime = 0.5f, panelAppearTime = 0.5f;
    [SerializeField]
    string APPEAR_FORWARD = "AppearFromRight", APPEAR_REVERSE = "AppearFromLeft", DISAPPEAR_FORWARD = "DisappearToLeft", DISAPPEAR_REVERSE = "DisappearToRight";
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void AppearForward()
    {
        gameObject.SetActive(true);
        Debug.Log("AppearForwardCalled");
        StartCoroutine(ShowPanel(APPEAR_FORWARD));
    }

    public void AppearReverse()
    {
        gameObject.SetActive(true);
        StartCoroutine(ShowPanel(APPEAR_REVERSE));
    }

    public void DisappearForward()
    {
        animator.SetBool(DISAPPEAR_FORWARD, true);
        StartCoroutine(RemovePanel());
    }

    public void DisappearReverse()
    {
        animator.SetBool(DISAPPEAR_REVERSE, true);
        StartCoroutine(RemovePanel());
    }
    IEnumerator RemovePanel()
    {
        yield return new WaitForSeconds(panelDisappearTime);
        gameObject.SetActive(false);
    }
    IEnumerator ShowPanel(string _animationName)
    {
        yield return new WaitForSeconds(panelAppearTime);
        animator.SetBool(_animationName, true);
        Debug.Log("Show Panel Coroutine ended");
    }
}
