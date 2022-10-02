using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK.InputModule;


public class ControllerModelManager : MonoBehaviour
{
     [SerializeField]
    private List<GameObject> controllerTutorialObjects;
    
    
    // Start is called before the first frame update
    void Start()
    {
        JMRInteractionManager.InteractionDeviceType deviceType; 
        deviceType = JMRInteractionManager.Instance.GetSupportedInteractionDeviceType();
        if (deviceType == JMRInteractionManager.InteractionDeviceType.JIOGLASS_CONTROLLER)
        {
            // gameObject.GetComponent<Image>().sprite = controllerSprites[0];
        }
        else if (deviceType == JMRInteractionManager.InteractionDeviceType.VIRTUAL_CONTROLLER)
        {
            // gameObject.GetComponent<Image>().sprite = controllerSprites[1];
        }
    }
}
