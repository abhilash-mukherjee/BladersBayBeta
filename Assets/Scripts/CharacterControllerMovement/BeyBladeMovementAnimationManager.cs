using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BeyBladeMovementAnimationManager : MonoBehaviour
{
    [SerializeField]
    private GameObject beyBladeParent;
    [SerializeField]
    private GameObject parentForChangingForwardRotation;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string speedParameter;
    [SerializeField]
    private float rotationLerpSpeed, turnUpLerpSpeed;
    [SerializeField]
    private GameObject trailLine;
    [SerializeField]
    private VectorVariable finalVelocity;
    private void Update()
    {
        if (finalVelocity.Value.magnitude <= 0.01f)
        {
            animator.SetFloat(speedParameter, 0);
            trailLine.SetActive(false);
            parentForChangingForwardRotation.transform.up =
               Vector3.Lerp(parentForChangingForwardRotation.transform.up,
               Vector3.up, Time.deltaTime * turnUpLerpSpeed);
            return;
        }
        animator.SetFloat(speedParameter, 1);
        trailLine.SetActive(true);
        parentForChangingForwardRotation.transform.forward =
           Vector3.Lerp(parentForChangingForwardRotation.transform.forward,
           finalVelocity.Value.normalized, Time.deltaTime * rotationLerpSpeed);
    }
}
