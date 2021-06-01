using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom3dLaserPointer : MonoBehaviour
{
    //singleton

    public static Custom3dLaserPointer m_instance;

    void Awake() => m_instance = this;

    public Transform m_handTransform;

    #region 3D
    private RaycastHit hit;
    public bool LaserHit()
    {
        //cast out a raycast that follows the laser's line renderer, get hit from collision on ray
        if (Physics.Raycast(m_handTransform.transform.position, m_handTransform.forward, out hit))
        {
            // if laser hits the layer return ture;
            if (hit.collider.gameObject.tag == "ColorSelector" || hit.collider.gameObject.tag == "image") return true;
        }

        return false;
    }
    public RaycastHit getHit() => hit;
    #endregion
}
