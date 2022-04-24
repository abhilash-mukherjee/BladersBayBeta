using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDisable_SD : MonoBehaviour
{
    public Vector3 start,end,startScale,endScale;
    // public float endf;
    public float speed = 10f;
    public float timeElapsed = 0f;

    public bool isY = false;
    void Start(){
        start = transform.position;
        startScale = transform.localScale;
        if(isY)
            end = new Vector3(transform.position.x,start.y + end.y,transform.position.z);
        else
            end = new Vector3(start.x + end.x,transform.position.y,transform.position.z);
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
