using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLaserOnLayer : MonoBehaviour
{
    public Canvas m_raycastCanvas;
    public TMPro.TextMeshProUGUI m_raycastText_01;
    public TMPro.TextMeshProUGUI m_raycastText_02;
    private float m_handRight;

    void Start()
    {
        m_raycastCanvas.enabled = true;
    }

    void Update()
    {
        m_handRight = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        // if the hand trigger is pressed
        if (m_handRight > 0.9f)
        {
            if (CustomLaserPointer.m_instance.LaserHit())
            {
                PrintDebug();
            }
        }
    }

    public void PrintDebug()
    {
        RaycastHit hit = CustomLaserPointer.m_instance.getHit();
        m_raycastText_01.text = $"Raycast location on layer :: {hit.point.ToString()}";
    }
}
