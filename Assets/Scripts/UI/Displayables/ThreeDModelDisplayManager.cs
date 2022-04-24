using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThreeDModelDisplayManager : MonoBehaviour, IDisplayable
{
    [SerializeField]
    private float objectDisappearTime = 0.5f, objectAppearTime = 0.5f;
    [SerializeField]
    string APPEAR_FORWARD = "In", APPEAR_REVERSE = "In", DISAPPEAR_FORWARD = "Out", DISAPPEAR_REVERSE = "Out";
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void AppearForward()
    {
        gameObject.SetActive(true);
        Debug.Log("AppearForwardCalled");
        StartCoroutine(ShowObject(APPEAR_FORWARD));
    }

    public void AppearReverse()
    {
        gameObject.SetActive(true);
        StartCoroutine(ShowObject(APPEAR_REVERSE));
    }

    public void DisappearForward()
    {
        animator.SetBool(DISAPPEAR_FORWARD, true);
        StartCoroutine(RemoveObject());
    }

    public void DisappearReverse()
    {
        animator.SetBool(DISAPPEAR_REVERSE, true);
        StartCoroutine(RemoveObject());
    }
    IEnumerator RemoveObject()
    {
        yield return new WaitForSeconds(objectDisappearTime);
        gameObject.SetActive(false);
    }
    IEnumerator ShowObject(string _animationName)
    {
        yield return new WaitForSeconds(objectAppearTime);
        animator.SetBool(_animationName, true);
        Debug.Log("Show Panel Coroutine ended");
    }
}
