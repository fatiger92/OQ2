using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLaserPointer : MonoBehaviour
{
    //singleton

    public static CustomLaserPointer m_instance;

    void Awake() => m_instance = this;

    public Transform m_handTransform;

    private RaycastHit hit;

    void Start() { }
    void Update() { }

    public bool LaserHit()
    {
        //cast out a raycast that follows the laser's line renderer, get hit from collision on ray
        if (Physics.Raycast(m_handTransform.transform.position, m_handTransform.forward, out hit))
        {
            // if laser hits the layer return ture;
            if (hit.collider.gameObject.tag == "image") return true;
        }

        return false;
    }

    public RaycastHit getHit() => hit;
}
