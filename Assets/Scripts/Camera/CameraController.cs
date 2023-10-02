using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera m_camera;


    // Start is called before the first frame update
    void Awake()
    {
        m_camera = GetComponent<Camera>();
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
            m_camera.orthographic = true;
        }
        else
        {
            // Switch to ThreeD
            m_camera.orthographic = false;
        }
    }
}
