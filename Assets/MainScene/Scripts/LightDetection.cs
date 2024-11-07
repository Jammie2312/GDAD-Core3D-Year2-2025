using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class LightDetection : MonoBehaviour
//{
//    [Header("Settings")]
//    [Tooltip("The camera who scans for light.")]
//    public Camera m_camLightScan;
//    [Tooltip("Show the light value in the log.")]
//    public bool m_bLogLightValue = false;
//    [Tooltip("Time between light value updates (default = 0.1f).")]
//    public float m_fUpdateTime = 0.1f;

//    public static float s_fLightValue;

//    private const int c_iTextureSize = 1000;

//    private Texture2D m_texLight;
//    private RenderTexture m_texTemp;
//    private Rect m_rectLight;
//    private Color m_LightPixel;

//    private void Start()
//    {
//        StartLightDetection();
//    }
//    private void StartLightDetection()
//    {
//        m_texLight = new Texture2D(c_iTextureSize, c_iTextureSize, TextureFormat.RGB24, false);
//        m_texTemp = new RenderTexture(c_iTextureSize, c_iTextureSize, 24);
//        m_rectLight = new Rect(0f, 0f, c_iTextureSize, c_iTextureSize);

//        StartCoroutine(LightDetectionUpdate(m_fUpdateTime));
//    }

//    private IEnumerator LightDetectionUpdate(float _fUpdateTime)
//    {
//        while (true)
//        {

//            m_camLightScan.targetTexture = m_texTemp;
//            m_camLightScan.Render();

//            RenderTexture.active = m_texTemp;
//            m_texLight.ReadPixels(m_rectLight, 0, 0);

//            RenderTexture.active = null;

//            m_camLightScan.targetTexture = null;

//            m_LightPixel = m_texLight.GetPixel(c_iTextureSize / 2, c_iTextureSize / 2);

//            s_fLightValue = (m_LightPixel.r + m_LightPixel.g + m_LightPixel.b) / 3f;

//            if (m_bLogLightValue)
//            {
//                Debug.Log("Light Value: " + s_fLightValue);
//            }

//            yield return new WaitForSeconds(_fUpdateTime);
//        }
//    }
//}
