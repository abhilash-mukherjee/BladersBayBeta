using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMRSDK.InputModule;


public class ControllerModelManager : MonoBehaviour
{
    [SerializeField]
    private List<UIDisplayable> proControllerTutorialObjects;
    [SerializeField]
    private List<UIDisplayable> virtualControllerTutorialObjects;
    [SerializeField]
    private GroupedDislayable groupedDislayable;
    [SerializeField]
    bool isControllerVirtual;
    
    // Start is called before the first frame update
    void Start()
    {
        JMRInteractionManager.InteractionDeviceType deviceType; 
        deviceType = JMRInteractionManager.Instance.GetSupportedInteractionDeviceType();
        if (deviceType == JMRInteractionManager.InteractionDeviceType.JIOGLASS_CONTROLLER)
        {
            if(proControllerTutorialObjects.Count >= 0)
            {
                foreach(var o in proControllerTutorialObjects)
                    groupedDislayable.PushDisplayable(o);
            }
            if(virtualControllerTutorialObjects.Count >= 0)
            {
                foreach(var o in virtualControllerTutorialObjects)
                    groupedDislayable.PopDisplayable(o);
            }
        }
        else if (deviceType == JMRInteractionManager.InteractionDeviceType.VIRTUAL_CONTROLLER)
        {
            if (proControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in proControllerTutorialObjects)
                    groupedDislayable.PopDisplayable(o);
            }
            if (virtualControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in virtualControllerTutorialObjects)
                    groupedDislayable.PushDisplayable(o);
            }
        }
        else if (isControllerVirtual)
        {
            if (proControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in proControllerTutorialObjects)
                    groupedDislayable.PopDisplayable(o);
            }
            if (virtualControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in virtualControllerTutorialObjects)
                    groupedDislayable.PushDisplayable(o);
            }
        }
        else
        {
            if (proControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in proControllerTutorialObjects)
                    groupedDislayable.PushDisplayable(o);
            }
            if (virtualControllerTutorialObjects.Count >= 0)
            {
                foreach (var o in virtualControllerTutorialObjects)
                    groupedDislayable.PopDisplayable(o);
            }
        }
    }
}
