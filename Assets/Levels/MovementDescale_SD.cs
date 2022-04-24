using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDescale_SD : MonoBehaviour
{
   public float speed = 10f;
    public float timeElapsed = 0f;
    // public bool isOpen = true;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.one,Vector3.zero,timeElapsed);
        timeElapsed += Time.deltaTime * speed;
    }
}
