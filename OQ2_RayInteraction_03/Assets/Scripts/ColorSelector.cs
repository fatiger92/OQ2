using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    public Canvas m_raycastCanvas;
    public TMPro.TextMeshProUGUI m_raycastText_01;
    public TMPro.TextMeshProUGUI m_raycastText_02;

    [SerializeField] private Texture2D m_textureSource;
    [SerializeField] private Image m_currtextureImage;
    [SerializeField] private bool m_includeAlphaChannel = true;
    [SerializeField] private Image m_colorView;

    private float m_handRight;

    private Color m_selectedColor;

    private Vector2 m_textureSizeOrigin;

    void Start()
    {
        //m_raycastCanvas.enabled = true;
        m_selectedColor = new Color();
        m_textureSizeOrigin = new Vector2(m_textureSource.width, m_textureSource.height);
    }

    #region 2D
    void Update()
    {
        m_handRight = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        // if the hand trigger is pressed
        if (m_handRight > 0.9f)
        {
            if (Custom2dLaserPointer.m_instance.LaserHit())
            {
                //PrintDebug();
                SelectColorAfterPrint();
            }
        }
    }

    public void PrintDebug()
    {
        //RaycastHit hit = Custom3dLaserPointer.m_instance.getHit(); //3d
        RaycastHit2D hit = Custom2dLaserPointer.m_instance.getHit(); //2d

        m_raycastText_01.text = $"{hit.collider.name} :: Raycast location on Color :: {hit.point.ToString()}";
    }

    public void SelectColorAfterPrint()
    {
        RaycastHit2D hit = Custom2dLaserPointer.m_instance.getHit(); //3d

        var mpos = hit.point;

        mpos = m_currtextureImage.rectTransform.InverseTransformPoint(mpos);

        mpos *= new Vector2(m_textureSource.width / m_currtextureImage.rectTransform.rect.width, m_textureSource.height / m_currtextureImage.rectTransform.rect.height);

        if ((mpos.x <= m_textureSizeOrigin.x / 2 && mpos.x >= -(m_textureSizeOrigin.x / 2)) && (mpos.y <= m_textureSizeOrigin.y / 2 && mpos.y >= -(m_textureSizeOrigin.y / 2)))
        {
            m_selectedColor = m_textureSource.GetPixel((int)(mpos.x + m_textureSizeOrigin.x / 2), (int)(mpos.y + m_textureSizeOrigin.y / 2));
        }
        if (!m_includeAlphaChannel) m_selectedColor.a = 1f;

        m_colorView.color = m_selectedColor;
        m_raycastText_01.text = $"Raycast location on Color :: {m_selectedColor.ToString()}";
    }

    #endregion


    #region 3D
    //void Update()
    //{
    //    m_handRight = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
    //    // if the hand trigger is pressed
    //    if (m_handRight > 0.9f)
    //    {
    //        if (Custom3dLaserPointer.m_instance.LaserHit())
    //        {
    //            //PrintDebug();
    //            SelectColorAfterPrint();
    //        }
    //    }
    //}

    //public void PrintDebug()
    //{
    //    RaycastHit hit = Custom3dLaserPointer.m_instance.getHit(); //3d
    //    //RaycastHit2D hit = Custom2dLaserPointer.m_instance.getHit(); //2d

    //    m_raycastText_01.text = $"{hit.collider.name} :: Raycast location on Color :: {hit.point.ToString()}";
    //}

    //public void SelectColorAfterPrint()
    //{
    //    RaycastHit hit = Custom3dLaserPointer.m_instance.getHit(); //3d

    //    var mpos = hit.point;

    //    mpos = m_currtextureImage.rectTransform.InverseTransformPoint(mpos);

    //    mpos *= new Vector2(m_textureSource.width / m_currtextureImage.rectTransform.rect.width, m_textureSource.height / m_currtextureImage.rectTransform.rect.height);

    //    if ((mpos.x <= m_textureSizeOrigin.x / 2 && mpos.x >= -(m_textureSizeOrigin.x / 2)) && (mpos.y <= m_textureSizeOrigin.y / 2 && mpos.y >= -(m_textureSizeOrigin.y / 2)))
    //    {
    //        m_selectedColor = m_textureSource.GetPixel((int)(mpos.x + m_textureSizeOrigin.x / 2), (int)(mpos.y + m_textureSizeOrigin.y / 2));
    //    }
    //    if (!m_includeAlphaChannel) m_selectedColor.a = 1f;

    //    m_colorView.color = m_selectedColor;
    //    m_raycastText_01.text = $"Raycast location on Color :: {m_selectedColor.ToString()}";
    //}
    #endregion
}
