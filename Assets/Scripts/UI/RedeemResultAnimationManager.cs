using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeemResultAnimationManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string appearAnimation;
    private void OnEnable()
    {
        animator.Play(appearAnimation);
    }
    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }
}
