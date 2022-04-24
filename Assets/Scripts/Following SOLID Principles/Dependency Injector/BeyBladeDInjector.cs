using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeDInjector : MonoBehaviour
{
    [SerializeField]
    private List<VelocityDecider> movementDirectors;
    [SerializeField]
    private SpeedDecider speedDecider;
    [SerializeField]
    private CharacterController characterController;

}
