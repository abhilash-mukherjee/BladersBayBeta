using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenElementRotationManager : MonoBehaviour
{
    [SerializeField]
    GameObject stadium;
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    Vector3 rotateAround;
 
    private void Update()
    {
        stadium.transform.Rotate(rotateAround, Time.deltaTime * speed);
    }
}
