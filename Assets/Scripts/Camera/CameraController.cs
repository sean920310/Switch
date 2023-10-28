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

    [SerializeField] public Volume vol;
    private int firstcontrol = 0;

    // Start is called before the first frame update
    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += Switch;
    }

    private void Start()
    {
        m_cameraTwoD.Follow = m_camTrackPos;
        m_cameraThreeD.Follow = m_camTrackPos;

        vol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    /// Switch Dimension State
    /// </summary>
    /// <param name="state">State to Switch</param>
    void Switch(CameraManager.Dimension state)
    {
        print("switch to " + state);
        if (state == CameraManager.Dimension.TwoD)
        {
            // Switch to TwoD
            m_cameraThreeD.m_Lens.FieldOfView = 60f;
            m_cameraTwoD.m_Lens.OrthographicSize = 3f;
            if(firstcontrol != 0) vol.enabled = true;
            firstcontrol = 1;
            m_cameraTwoD.Priority = 1;
            m_cameraThreeD.Priority = 0;
        }
        else
        {
            // Switch to ThreeD
            m_cameraTwoD.m_Lens.OrthographicSize = 3f;
            m_cameraThreeD.m_Lens.FieldOfView = 60f;
            if (firstcontrol != 0) vol.enabled = true;
            firstcontrol = 1;
            m_cameraTwoD.Priority = 0;
            m_cameraThreeD.Priority = 1;

        }
        Invoke("disable_volume", 0.4f);
    }

    void disable_volume()
    {
        vol.enabled = false;
    }
}
