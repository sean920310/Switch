using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera m_cameraTwoD;
    [SerializeField]
    private CinemachineVirtualCamera m_cameraThreeD;
    [SerializeField]
    private Transform m_camTrackPos;
    
    [SerializeField]
    private float m_canvasDistance2D;
    [SerializeField]
    private float m_canvasDistance3D;
    [SerializeField]
    private Canvas m_playerRenderCanvas;
    [SerializeField] 
    private Volume m_switchEffectVol;
    [SerializeField]
    private float m_switchEffectSpeed;

    private float m_effectWeight = 0f;
    private bool m_isAppQuiting = false;


    // Start is called before the first frame update
    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += Switch;
    }

    private void Start()
    {
        m_cameraTwoD.Follow = m_camTrackPos;
        m_cameraThreeD.Follow = m_camTrackPos;

        //m_switchEffecVol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_switchEffectVol.weight!= 0 || m_effectWeight !=0)
            m_switchEffectVol.weight = Mathf.Lerp(m_switchEffectVol.weight, m_effectWeight, m_switchEffectSpeed * Time.deltaTime);
        if (m_switchEffectVol.weight < 0.001f) m_switchEffectVol.weight = 0f;
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if(!m_isAppQuiting)
            CameraManager.Instance.OnSwitchCallback -= Switch;
    }

    /// <summary>
    /// Switch Dimension State
    /// </summary>
    /// <param name="state">State to Switch</param>
    void Switch(CameraManager.Dimension state)
    {
        print("switch to " + state);
       // m_switchEffecVol.enabled = true;
        m_effectWeight = 1f;
        if (state == CameraManager.Dimension.TwoD)
        {
            // Switch to TwoD
            m_cameraTwoD.Priority = 1;
            m_cameraThreeD.Priority = 0;
            m_playerRenderCanvas.planeDistance = m_canvasDistance2D;
        }
        else
        {
            // Switch to ThreeD
            m_cameraTwoD.Priority = 0;
            m_cameraThreeD.Priority = 1;
            m_playerRenderCanvas.planeDistance = m_canvasDistance3D;
        }
        Invoke("DisableVolume", 0.4f);
    }

    void DisableVolume()
    {
        m_effectWeight = 0f;
        //m_switchEffecVol.enabled = false;
    }
}
