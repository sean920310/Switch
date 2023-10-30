using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField]
    private List<Material> m_backgroundMat;

    [SerializeField]
    private float m_fadeSpeed;

    private float m_fadeAlpha = 0;
    private bool m_isFading = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        CameraManager.Instance.OnSwitchCallback += OnSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isFading)
        {
            m_fadeAlpha = Mathf.Lerp(0, 0.3f, Mathf.PingPong(Time.time * m_fadeSpeed, 1.0f));
            SetOutlineAlpha(m_fadeAlpha);
        }
    }

    void OnDisable()
    {
        SetOutlineAlpha(0);
        CameraManager.Instance.OnSwitchCallback -= OnSwitch;
    }

    void SetOutlineAlpha(float alpha)
    {
        foreach (Material mat in m_backgroundMat)
        {
            Color temp = mat.GetColor("_OutlineColor");
            temp.a = alpha;
            mat.SetColor("_OutlineColor", temp);
        }
    }

    void OnSwitch(CameraManager.Dimension state)
    {
        if(state == CameraManager.Dimension.ThreeD)
        {
            m_isFading = true;
        }
        else
        {
            m_isFading = false;
            SetOutlineAlpha(0);
        }
    }
}
