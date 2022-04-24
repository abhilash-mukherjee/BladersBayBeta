using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMarkerRotationManager : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Vector3 axisOfRotation;
    private void Update()
    {
        axisOfRotation.Normalize();
        transform.Rotate(axisOfRotation, rotationSpeed * Time.deltaTime);
    }
}
