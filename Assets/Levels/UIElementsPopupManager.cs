using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsPopupManager : MonoBehaviour
{
    public Vector3 start,end;
    public bool isScale;
    public float timeElapsed;
    [SerializeField]
    private Vector3 ActiveScale = Vector3.one;
    [SerializeField]
    private float animationSpeed = 2;
    public void AnimateUIStart(bool isReversed){
        if(!isScale)
            gameObject.transform.localScale = ActiveScale;
        if (isReversed){
            StartCoroutine(AnimateUIReverse());
        }
        else{
            StartCoroutine(AnimateUI());
        }

    }


    IEnumerator AnimateUI(){
        Vector3 startPos = start;
        Vector3 endPos = end;
        Vector3 trans = isScale ? transform.localScale : transform.localPosition;
        
        while(trans != endPos)
        {

            if(isScale){
                
                transform.localScale = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localScale;
            }else{
                transform.localPosition = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localPosition;
            }
            timeElapsed += Time.deltaTime * animationSpeed;

            yield return null;
        }
        timeElapsed = 0;
        if(!isScale){
            gameObject.transform.localScale = Vector3.zero;
        }
    }

    IEnumerator AnimateUIReverse(){
        Vector3 trans = isScale ? transform.localScale : transform.position;
        Vector3 startPos = end;
        Vector3 endPos = start;
        while(trans != endPos){
            if(isScale){
                transform.localScale = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localScale;
            }else{
                transform.localPosition = Vector3.Lerp(startPos,endPos,timeElapsed);
                trans = transform.localPosition;
            }
            timeElapsed += Time.deltaTime * animationSpeed;

            yield return null;
        }

        timeElapsed = 0;
    }


}
