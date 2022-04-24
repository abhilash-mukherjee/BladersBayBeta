using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate1_SD : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.0f, 10000.0f)]
    public float speed = 90f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }
}
