using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadowControl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_shadow;

    private bool m_isAppQuiting = false;

    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }

    private void Start()
    {
        OnSwitch(CameraManager.Instance.DimensionState);
    }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if (!m_isAppQuiting)
            CameraManager.Instance.OnSwitchCallback -= OnSwitch;
    }

    void OnSwitch(CameraManager.Dimension state)
    {
        if(state == CameraManager.Dimension.ThreeD)
        {
            m_shadow.enabled = true;
        }
        else
        {
            m_shadow.enabled = false;
        }
    }
}
