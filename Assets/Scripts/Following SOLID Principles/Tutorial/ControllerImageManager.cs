using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JMRSDK.InputModule;

public class ControllerImageManager : MonoBehaviour
{
     [SerializeField]
    private List<Sprite> controllerSprites;
    
    
    // Start is called before the first frame update
    void Start()
    {
        JMRInteractionManager.InteractionDeviceType deviceType; 
        deviceType = JMRInteractionManager.Instance.GetSupportedInteractionDeviceType();
        if (deviceType == JMRInteractionManager.InteractionDeviceType.JIOGLASS_CONTROLLER)
        {
            gameObject.GetComponent<Image>().sprite = controllerSprites[0];
        }
        else if (deviceType == JMRInteractionManager.InteractionDeviceType.VIRTUAL_CONTROLLER)
        {
            gameObject.GetComponent<Image>().sprite = controllerSprites[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
