using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera m_cameraTwoD;
    [SerializeField]
    private CinemachineVirtualCamera m_cameraThreeD;


    // Start is called before the first frame update
    void Start()
    {
        CameraManager.Instance.OnSwitchCallback += Switch;
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
            m_cameraTwoD.Priority = 1;
            m_cameraThreeD.Priority = 0;
        }
        else
        {
            // Switch to ThreeD
            m_cameraTwoD.Priority = 0;
            m_cameraThreeD.Priority = 1;
        }
    }
}