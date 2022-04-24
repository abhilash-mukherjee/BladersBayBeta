using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transitionObject;
    int count = 0;
    bool click = false;
    public void AnimationTrigger(){
        // count ++;
        if(count == 0){
            transitionObject.GetComponent<Animator>().SetBool("StartTransition",true);
            count = 1;
            return;
        }
        Debug.Log(count);
        click = !click;
        transitionObject.GetComponent<Animator>().SetBool("Transition",click);
    }
}
