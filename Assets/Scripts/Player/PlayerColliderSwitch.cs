using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerColliderSwitch : MonoBehaviour
{
    [Header("3D")]

    [SerializeField]
    private Vector2 m_colliderSize3D;
    [SerializeField]
    private Vector2 m_colliderOffset3D;


    [Header("2D")]

    [SerializeField]
    private Vector2 m_colliderSize2D;
    [SerializeField]
    private Vector2 m_colliderOffset2D;

    private bool m_isAppQuiting = false;

    private void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }

    // Update is called once per frame
    // private void LateUpdate()
    // {
    //     if (CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD)
    //     {
    //         GetComponent<BoxCollider2D>().size = new Vector2(colliderSize3D_x, colliderSize3D_y);
    //         GetComponent<BoxCollider2D>().offset = new Vector2(colliderOffset3D_x, colliderOffset3D_y);
    //         //camTarget.transform.localPosition = new Vector3(0f, 1.403f, -0.6f);
    //     }
    //     else
    //     {
    //         GetComponent<BoxCollider2D>().size = new Vector2(0.3779367f, 1.591878f);
    //         GetComponent<BoxCollider2D>().offset = new Vector2(0.1072523f, 0.005540371f);
    //         //camTarget.transform.localPosition = new Vector3(0f, 1.403f, 0f);
    //     }
    // }

    private void OnApplicationQuit()
    {
        m_isAppQuiting = true;
    }

    private void OnDisable()
    {
        if(!m_isAppQuiting)
            CameraManager.Instance.OnSwitchCallback -= OnSwitch;
    }

    void OnSwitch(CameraManager.Dimension state)
    {
        if (CameraManager.Instance.DimensionState == CameraManager.Dimension.ThreeD)
        {
            GetComponent<BoxCollider2D>().size = m_colliderSize3D;
            GetComponent<BoxCollider2D>().offset = m_colliderOffset3D;
        }
        else
        {
            GetComponent<BoxCollider2D>().size = m_colliderSize2D;
            GetComponent<BoxCollider2D>().offset = m_colliderOffset2D;
        }
    }
}
