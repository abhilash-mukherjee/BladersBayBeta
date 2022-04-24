using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualControllerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject backPart;
    //[SerializeField]
    //private GameObject particles;
    private Vector3 backPartPosition;
    public Vector3 controllerPosition
    {
        get { return backPartPosition; }
    }
    private void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Stadium"))
            return;
        backPartPosition = backPart.transform.position;
        //Instantiate(particles, backPartPosition, Quaternion.identity);
    }
}
