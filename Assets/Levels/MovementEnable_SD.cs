using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnable_SD : MonoBehaviour
{
    public Vector3 start,end,startScale,endScale;
    // public float endf;
    public float speed = 10f;
    public float timeElapsed = 0f;

    public bool isY = false;
    void Start(){
        start = transform.position;
        
        if(!isY)
            end = new Vector3(0,0,transform.position.z);            
    }

    void Update(){
        Movement();
    }

    void Movement(){
        transform.position = Vector3.Lerp(start,end,timeElapsed);
        transform.localScale = Vector3.Lerp(startScale,endScale,timeElapsed);
        timeElapsed += Time.deltaTime * speed;
    }
}
