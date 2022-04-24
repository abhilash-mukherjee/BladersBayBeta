using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateManager_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject>  gameObjects;
    public List<GameObject> tipCollections;
    int count = 0;

    // [System.Obsolete]
    int getActiveObject(){
        for(int i=0;i<gameObjects.Count;i++){
            if(gameObjects[i].activeSelf){
                return i;
            }
        }

        return -1;
    }
    
    public void ClickEvent(){
        count = getActiveObject();
        for(int i=0;i<gameObjects.Count;i++){
            gameObjects[i].SetActive(false);
            tipCollections[i].SetActive(false);
        }
        count = (count+1) % gameObjects.Count;
        gameObjects[count].SetActive(true);
        tipCollections[count].SetActive(true);
    }

    public void ClickEventOpposite(){
        count = getActiveObject();
        for(int i=0;i<gameObjects.Count;i++){
            gameObjects[i].SetActive(false);
            tipCollections[i].SetActive(false);
        }
        count --;
        if(count < 0){
            count = gameObjects.Count-1;
        }
        
        Debug.Log(count);

        gameObjects[count].SetActive(true);
        tipCollections[count].SetActive(true);
    }
}
