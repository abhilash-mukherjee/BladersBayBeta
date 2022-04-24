using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimationManager : MonoBehaviour
{
    public GameEvent OnDeathAnimationFinished;
    [SerializeField]
    private FloatVariable HP;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string AnimParam;
    private void Update()
    {
        float val = HP.Value / 100f;
        animator.SetFloat(AnimParam,val);
    }
    public void AnimationFinished()
    {
        OnDeathAnimationFinished.Raise();
    }
}
