using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScale_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float timeElapsed = 0f;
    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one,timeElapsed);
        timeElapsed += Time.deltaTime * speed;
    }
}
