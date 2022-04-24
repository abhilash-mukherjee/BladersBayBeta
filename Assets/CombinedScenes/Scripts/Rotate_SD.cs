using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_SD : MonoBehaviour
{
    [Range(0.0f, 10000.0f)]
    public float speed = 90f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * speed);
    }
}
