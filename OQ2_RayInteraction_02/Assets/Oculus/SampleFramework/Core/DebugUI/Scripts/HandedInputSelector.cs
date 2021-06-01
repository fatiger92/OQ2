/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.  

See SampleFramework license.txt for license terms.  Unless required by applicable law 
or agreed to in writing, the sample code is provided �AS IS� WITHOUT WARRANTIES OR 
CONDITIONS OF ANY KIND, either express or implied.  See the license for specific 
language governing permissions and limitations under the license.

************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class HandedInputSelector : MonoBehaviour
{
    OVRCameraRig m_CameraRig;
    OVRInputModule m_InputModule;

    [HideInInspector]
    public OVRInput.Controller activeController = OVRInput.Controller.None;

    void Start()
    {
        m_CameraRig = FindObjectOfType<OVRCameraRig>();
        m_InputModule = FindObjectOfType<OVRInputModule>();
    }

    void Update()
    {
        activeController = GetControllerForButton(OVRInput.Button.PrimaryIndexTrigger, activeController);

        if (activeController == OVRInput.Controller.LTouch) SetActiveController(OVRInput.Controller.LTouch);
        else if (activeController == OVRInput.Controller.RTouch) SetActiveController(OVRInput.Controller.RTouch);
    }

    // below modified

    public static OVRInput.Controller GetControllerForButton(OVRInput.Button joyPadClickButton, OVRInput.Controller oldController)
    {
        OVRInput.Controller controller = OVRInput.GetConnectedControllers();

        if ((controller & OVRInput.Controller.RTouch) == OVRInput.Controller.RTouch)
        {
            if (OVRInput.Get(joyPadClickButton, OVRInput.Controller.RTouch) || oldController == OVRInput.Controller.None)
            {
                return OVRInput.Controller.RTouch;
            }
        }

        if ((controller & OVRInput.Controller.LTouch) == OVRInput.Controller.LTouch)
        {
            if (OVRInput.Get(joyPadClickButton, OVRInput.Controller.LTouch) || oldController == OVRInput.Controller.None)
            {
                return OVRInput.Controller.LTouch;
            }
        }

        if ((controller & oldController) != oldController)
        {
            return OVRInput.Controller.None;
        }

        return oldController;
    }

    void SetActiveController(OVRInput.Controller c)
    {
        Transform t;
        if(c == OVRInput.Controller.LTouch)
        {
            t = m_CameraRig.leftHandAnchor;
        }
        else
        {
            t = m_CameraRig.rightHandAnchor;
        }
        m_InputModule.rayTransform = t;
    }
}
